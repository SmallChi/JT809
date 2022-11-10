# JT809协议

[![MIT Licence](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/SmallChi/JT809/blob/master/LICENSE)![.NET Core](https://github.com/SmallChi/JT809/workflows/.NET%20Core/badge.svg?branch=master)

## 前提条件

1. 掌握进制转换：二进制转十六进制；
2. 掌握BCD编码、Hex编码；
3. 掌握各种位移、异或；
4. 掌握常用反射；
5. 掌握JObject的用法；
6. 掌握快速ctrl+c、ctrl+v；
7. 掌握Span\<T\>的基本用法；
8. 掌握以上装逼技能，就可以开始搬砖了。

## JT809数据结构解析

### 数据包[JT809Package]

|头标识|数据头|数据体|CRC校验码|尾标识
|:------:|:------:|:------:|:------:|:------:|
|  BeginFlag  | JT809Header  |  JT809Bodies  | CRCCode | EndFlag |
|  5B  | - | - | - | 5D |

### 数据头[JT809Header]

|数据长度|报文序列号|业务数据类型|下级平台接入码|协议版本号标识|报文加密标识位|数据加密的密匙|发送消息的系统时间(2019版本)|
|:------:|:------:|:------:|:------:|:------:|:------:|:------:|:------:|
| MsgLength | MsgSN | BusinessType | MsgGNSSCENTERID | Version |EncryptFlag | EncryptKey |Time|

### 数据体[JT809Bodies]

> 根据对应业务数据类型：BusinessType

|车牌号|车辆颜色|子业务类型标识|后续数据长度|子业务数据体
|:------:|:------:|:------:|:------:|:------:|
|  VehicleNo  | VehicleColor  |  SubBusinessType  | DataLength | JT809SubBodies |

### 子数据体[JT809SubBodies]

> 根据对应子业务数据类型 SubBusinessType 处理子业务数据体(JT809SubBodies)。

***注意：数据内容(除去头和尾标识)进行转义判断***

转义规则如下:

1. 若数据内容中有出现字符 0x5b 的，需替换为字符 0x5a 紧跟字符 0x01;
2. 若数据内容中有出现字符 0x5a 的，需替换为字符 0x5a 紧跟字符 0x02;
3. 若数据内容中有出现字符 0x5d 的，需替换为字符 0x5e 紧跟字符 0x01;
4. 若数据内容中有出现字符 0x5e 的，需替换为字符 0x5e 紧跟字符 0x02.

反转义的原因：确认JT809协议的TCP消息边界。

### 举个栗子1

#### 1.组包：

> 业务数据类型 BusinessType:从链路报警信息交互消息
>
> 子业务类型标识 SubBusinessType:报警督办请求消息

``` code
JT809Package jT809Package = new JT809Package();

jT809Package.Header = new JT809Header
{
    MsgSN = 1666,
    EncryptKey = 9999,
    EncryptFlag= JT809Header_Encrypt.None,
    Version = new JT809Header_Version(1, 0, 0),
    BusinessType = JT809BusinessType.从链路报警信息交互消息.ToUInt16Value(),
    MsgGNSSCENTERID = 20180920,
};

JT809_0x9400 bodies = new JT809_0x9400
{
    VehicleNo="粤A12345",
    VehicleColor= JT809VehicleColorType.黄色,
    SubBusinessType= JT809SubBusinessType.报警督办请求消息.ToUInt16Value(),
};

JT809_0x9400_0x9401 jT809_0x9400_0x9401 = new JT809_0x9400_0x9401
{
    WarnSrc = JT809WarnSrc.车载终端,
    WarnType = JT809WarnType.疲劳驾驶报警.ToUInt16Value(),
    WarnTime = DateTime.Parse("2018-09-27 10:24:00"),
    SupervisionID = "123FFAA1",
    SupervisionEndTime = DateTime.Parse("2018-09-27 11:24:00"),
    SupervisionLevel = 3,
    Supervisor = "smallchi",
    SupervisorTel = "12345678901",
    SupervisorEmail = "123456@qq.com"
};

bodies.SubBodies = jT809_0x9400_0x9401;

jT809Package.Bodies = bodies;

byte[] data = JT809Serializer.Serialize(jT809Package);

string hex = data.ToHexString();

// 输出结果Hex：
// 5B 00 00 00 92 00 00 06 82 94 00 01 33 EF B8 01 00 00 00 00 00 27 0F D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 94 01 00 00 00 5C 01 00 02 00 00 00 00 5A 01 AC 3F 40 12 3F FA A1 00 00 00 00 5A 01 AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BA D8 5D
```

#### 2.手动解包：

``` data
1.原包：
5B 00 00 00 92 00 00 06 82 94 00 01 33 EF B8 01 00 00 00 00 00 27 0F D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 94 01 00 00 00 5C 01 00 02 00 00 00 00 (5A 01) AC 3F 40 12 3F FA A1 00 00 00 00 (5A 01) AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BA D8 5D

2.进行反转义
5A 01 ->5B
5A 02 ->5A
5E 01 ->5D
5E 02 ->5E
反转义后
5B 00 00 00 92 00 00 06 82 94 00 01 33 EF B8 01 00 00 00 00 00 27 0F D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 94 01 00 00 00 5C 01 00 02 00 00 00 00 5B AC 3F 40 12 3F FA A1 00 00 00 00 5B AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BA D8 5D

3.拆解
5B          --头标识
00 00 00 92 --数据头->数据长度
00 00 06 82 --数据头->报文序列号
94 00       --数据头->业务数据类型
01 33 EF B8 --数据头->下级平台接入码，上级平台给下级平台分配唯一标识码
01 00 00    --数据头->协议版本号标识
00          --数据头->报文加密标识位
00 00 27 0F --数据头->数据加密的密匙
D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 --数据体->车牌号
02                                                             --数据体->车辆颜色
94 01                                                          --数据体->子业务类型标识
00 00 00 5C                                                    --数据体->后续数据长度
01                                                                                              --子数据体->报警信息来源
00 02                                                                                           --子数据体->报警类型
00 00 00 00 5B AC 3F 40                                                                         --子数据体->报警时间UTCDateTime
12 3F FA A1                                                                                     --子数据体->报警督办ID
00 00 00 00 5B AC 4D 50                                                                         --子数据体->督办截止时间
03                                                                                              --子数据体->督办级别
73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00                                                 --子数据体->督办人
31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00                                     --子数据体->督办联系电话
31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 --子数据体->督办联系电子邮件
BA D8       --CRC校验码
5D          --尾标识
```

#### 3.程序解包：

``` data
//1.转成byte数组
var bytes = "5B 00 00 00 92 00 00 06 82 94 00 01 33 EF B8 01 00 00 00 00 00 27 0F D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 94 01 00 00 00 5C 01 00 02 00 00 00 00 5A 01 AC 3F 40 12 3F FA A1 00 00 00 00 5A 01 AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BA D8 5D".ToHexBytes();

//2.将数组反序列化
JT809Package jT809Package = JT809Serializer.Deserialize(bytes);

//3.数据包头
Assert.Equal((uint)146, jT809Package.Header.MsgLength);
Assert.Equal((uint)1666, jT809Package.Header.MsgSN);
Assert.Equal((uint)9999, jT809Package.Header.EncryptKey);
Assert.Equal(JT809Header_Encrypt.None, jT809Package.Header.EncryptFlag);
Assert.Equal((uint)20180920, jT809Package.Header.MsgGNSSCENTERID);
Assert.Equal(JT809BusinessType.从链路报警信息交互消息, (JT809BusinessType)jT809Package.Header.BusinessType);
Assert.Equal(new JT809Header_Version(1, 0, 0).ToString(), jT809Package.Header.Version.ToString());

//4.数据包体
JT809_0x9400 jT809_0X400 = (JT809_0x9400)jT809Package.Bodies;
Assert.Equal("粤A12345", jT809_0X400.VehicleNo);
Assert.Equal(JT809VehicleColorType.黄色, jT809_0X400.VehicleColor);
Assert.Equal(JT809SubBusinessType.报警督办请求消息, (JT809SubBusinessType)jT809_0X400.SubBusinessType);
Assert.Equal((uint)92, jT809_0X400.DataLength);

//5.子数据包体
JT809_0x9400_0x9401 jT809_0x9400_0x9401 = (JT809_0x9400_0x9401)jT809_0X400.JT809SubBodies;
Assert.Equal(JT809WarnSrc.车载终端, jT809_0x9400_0x9401.WarnSrc);
Assert.Equal(JT809WarnType.疲劳驾驶报警, (JT809WarnType)jT809_0x9400_0x9401.WarnType);
Assert.Equal(DateTime.Parse("2018-09-27 10:24:00"), jT809_0x9400_0x9401.WarnTime);
Assert.Equal("123FFAA1", jT809_0x9400_0x9401.SupervisionID);
Assert.Equal(DateTime.Parse("2018-09-27 11:24:00"), jT809_0x9400_0x9401.SupervisionEndTime);
Assert.Equal(3, jT809_0x9400_0x9401.SupervisionLevel);
Assert.Equal("smallchi", jT809_0x9400_0x9401.Supervisor);
Assert.Equal("12345678901", jT809_0x9400_0x9401.SupervisorTel);
Assert.Equal("123456@qq.com", jT809_0x9400_0x9401.SupervisorEmail);

```

### 举个栗子2

``` data2
// 根据业务类型创建对应包
JT809Package jT809Package = JT809BusinessType.从链路报警信息交互消息.Create_从链路报警信息交互消息(
    new JT809Header
    {
        MsgSN = 1666,
        EncryptKey = 9999,
        EncryptFlag = JT809Header_Encrypt.None,
        Version = new JT809Header_Version(1, 0, 0),
        MsgGNSSCENTERID = 20180920,
    }, new JT809_0x9400
    {
        VehicleNo = "粤A12345",
        VehicleColor = JT809VehicleColorType.黄色,
        SubBusinessType = JT809SubBusinessType.报警督办请求消息.ToUInt16Value(),
        SubBodies = JT809SubBusinessType.报警督办请求消息.Create_报警督办请求消息(
            new JT809_0x9400_0x9401
            {
                WarnSrc = JT809WarnSrc.车载终端,
                WarnType = JT809WarnType.疲劳驾驶报警.ToUInt16Value(),
                WarnTime = DateTime.Parse("2018-09-27 10:24:00"),
                SupervisionID = "123FFAA1",
                SupervisionEndTime = DateTime.Parse("2018-09-27 11:24:00"),
                SupervisionLevel = 3,
                Supervisor = "smallchi",
                SupervisorTel = "12345678901",
                SupervisorEmail = "123456@qq.com"
            })
    }
);
var hex = JT809Serializer.Serialize(jT809Package).ToHexString();
```

### 举个栗子3

``` data3
static void Main(string[] args)
{
    class JT809GlobalConfig: GlobalConfigBase
    {
        public override JT809EncryptOptions EncryptOptions { get; set; }= new JT809EncryptOptions()
        {
            IA1 = 20000000,
            IC1 = 20000000,
            M1 = 30000000
        };
        public override string ConfigId => "JT809GlobalConfig";
    }
    JT809Serializer JT809Serializer = new JT809Serializer(new JT809GlobalConfig());
    // todo:
}
```

### 举个栗子4

如何在项目中同时使用809的2011和2019版本

``` data4
IServiceCollection serviceDescriptors = new ServiceCollection();
serviceDescriptors.AddJT809Configure(new JT809_2011_Config());
serviceDescriptors.AddJT809Configure(new JT809_2019_Config());
JT809Serializer JT809_2011_Serializer= ServiceProvider.GetRequiredService<JT809_2011_Config>().GetSerializer();
JT809Serializer JT809_2019_Serializer = ServiceProvider.GetRequiredService<JT809_2019_Config>().GetSerializer();
public class JT809_2011_Config: JT809GlobalConfigBase
{
    public override string ConfigId => "JT809_2011";
}
public class JT809_2019_Config : JT809GlobalConfigBase
{
    public override string ConfigId => "JT809_2019";
    public JT809_2019_Config()
    {
        Version = JT809Version.JTT2019;
    }
}
```

### 举个栗子5

如何在项目中同时使用808的2019版本和809的2019版本

``` data4
IServiceCollection serviceDescriptors = new ServiceCollection();
serviceDescriptors.AddJT808Configure(new JT808_2019_Config());
serviceDescriptors.AddJT809Configure(new JT809_2019_Config());
JT808Serializer JT808_2019_Serializer = ServiceProvider.GetRequiredService<JT808_2019_Config>().GetSerializer();
JT809Serializer JT809_2019_Serializer = ServiceProvider.GetRequiredService<JT809_2019_Config>().GetSerializer();
public class JT808_2019_Config : GlobalConfigBase
{
    public override string ConfigId { get; protected set; }
    public JT808_2019_Config(string configId = "jt808_2019")
    {
        ConfigId = configId;
    }
}
public class JT809_2019_Config : JT809GlobalConfigBase
{
    public override string ConfigId => "JT809_2019";
    public JT809_2019_Config()
    {
        Version = JT809Version.JTT2019;
    }
}
```

## NuGet安装

| Package Name |  Version | Pre Version |Downloads
|--------------|  ------- | ------- |----
| Install-Package JT809 | ![JT809](https://img.shields.io/nuget/v/JT809.svg) | ![JT809](https://img.shields.io/nuget/vpre/JT809.svg) |![JT809](https://img.shields.io/nuget/dt/JT809.svg)
| Install-Package JT809.Protocol.Extensions.JT1078 | ![JT809.Protocol.Extensions.JT1078](https://img.shields.io/nuget/v/JT809.Protocol.Extensions.JT1078.svg) | ![JT809.Protocol.Extensions.JT1078](https://img.shields.io/nuget/vpre/JT809.Protocol.Extensions.JT1078.svg) |![JT809](https://img.shields.io/nuget/dt/JT809.Protocol.Extensions.JT1078.svg) |

## 使用BenchmarkDotNet性能测试报告（只是玩玩，不能当真）

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  Job-WBHHQZ : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

Platform=AnyCpu  Server=False  Toolchain=.NET 7.0  

```

Method |      N |         Mean |       Error |      StdDev |       Gen0 |   Allocated |
---------------------------------------- |------- |-------------:|------------:|------------:|-----------:|------------:|
 **JT809_0x9400_0x9401_Package_Deserialize** |    **100** |     **486.9 μs** |     **9.46 μs** |    **11.62 μs** |    **16.6016** |   **103.13 KB** |
   JT809_0x9400_0x9401_Package_Serialize |    100 |     192.0 μs |     3.66 μs |     4.63 μs |    14.6484 |    90.63 KB |
 **JT809_0x9400_0x9401_Package_Deserialize** |  **10000** |  **48,395.5 μs** |   **823.85 μs** |   **770.63 μs** |  **1636.3636** | **10312.57 KB** |
   JT809_0x9400_0x9401_Package_Serialize |  10000 |  19,033.4 μs |   279.80 μs |   248.04 μs |  1468.7500 |  9062.53 KB |
 **JT809_0x9400_0x9401_Package_Deserialize** | **100000** | **492,172.8 μs** | **9,680.82 μs** | **9,507.86 μs** | **16000.0000** | **103125.8 KB** |
   JT809_0x9400_0x9401_Package_Serialize | 100000 | 189,518.7 μs | 2,357.11 μs | 2,204.84 μs | 14666.6667 | 90625.27 KB |

## JT809协议消息对照表

> ***2019版8.3.3.2.5 新增的 交换车辆行驶路线信息消息，无对应消息子id类型，暂未对接***

### 链路管理类

#### 主链路

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1   | 0x1001  |  √  |  √  | 主链路登录请求消息 |  
|  2   | 0x1002  |  √  |  √  | 主链路登录应答消息 |  
|  3   | 0x1003  |  √  |  √  | 主链路注销请求消息 |  
|  4   | 0x1004  |  √  |  √  | 主链路注销应答消息 |  
|  5   | 0x1005  |  √  |  √  | 主链路连接保持请求消息 |
|  6   | 0x1006  |  √  |  √  | 主链路连接保持应答消息 |
|  7   | 0x1007  |  √  |  √  | 主链路断开通知消息  |
|  8   | 0x1008  |  √  |  √  |下级平台主动关闭链路通知消息  |

#### 从链路

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x9001  |  √  |  √  | 从链路连接请求消息  |
|  2  | 0x9002  |  √  |  √  | 从链路连接应答消息  |
|  3  | 0x9003  |  √  |  √  | 从链路注销请求消息  |
|  4  | 0x9004  |  √  |  √  | 从链路注销应答消息  |
|  5  | 0x9005  |  √  |  √  | 从链路连接保持请求消息  |
|  6  | 0x9006  |  √  |  √  | 从链路连接保持应答消息  |
|  7  | 0x9007  |  √  |  √  | 从链路断开通知消息 |
|  8  | 0x9008  |  √  |  √  | 上级平台主动关闭链路通知消息 |

### 信息统计类

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x9101  |  √  |   √  |接收定位信息数量通知消息  |
|  1  | 0x9102  |  √  |   √  |平台链路连接情况与车辆定位消息传输情况上报请求消息  |
|  1  | 0x9103  |  √  |   √  |下发平台间消息序列号通知消息  |

### 车辆动态信息交换

#### 主链路动态信息交换消息

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x1200  |  √   |  √  | 主链路动态信息交换消息 |
|  2  | 0x1201  |  √   |  √  | 上传车辆注册信息(809补充协议文档)  |
|  3  | 0x1202  |  √   |  √  | 实时上传车辆定位信息  |
|  4  | 0x1203  |  √   |  √  | 车辆定位信息自动补报  |
|  5  | 0x1205  |  √   |  √  | 启动车辆定位信息交换应答消息  |
|  6  | 0x1206  |  √   |  √  | 结束车辆定位信息交换应答消息  |
|  7  | 0x1207  |  √   |  √  | 申请交换指定车辆定位信息请求消息 |
|  8  | 0x1208  |  √   |  √  | 取消交换指定车辆定位信息请求  |
|  9  | 0x1209  |  √   |  √  | 补发车辆定位信息请求  |
|  10 | 0x120A  |  √   |  √  | 上报车辆驾驶员身份识别信息应答 |
|  11 | 0x120B  |  √   |  √  | 上报车辆电子运单应答  |
|  12 | 0x120C  |  √   |  √  | 主动上报驾驶员身份信息  |
|  13 | 0x120D  |  √   |  √  | 主动上报车辆电子运单信息  |
|  14 | 0x120E  |  √   |  √  | 主动上报车辆行驶路线信息(809-2019)  |

#### 从链路动态信息交换消息

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x9200  |  √   |  √   |  从链路动态信息交换消息  |
|  1  | 0x9201  |  √   |  √(0x1201)   |  车辆注册信息应答消息  |
|  2  | 0x9202  |  √   |  √(0x1202)   |  交换车辆定位信息消息(809补充协议文档)  |
|  3  | 0x9203  |  √   |  √(0x1203)   |  车辆定位信息交换补发消息  |
|  4  | 0x9204  |  √   |  √   |  交换车辆静态信息消息  |
|  5  | 0x9205  |  √   |  √   |  启动车辆定位信息交换请求消息  |
|  6  | 0x9206  |  √   |  √   |  结束车辆定位信息交换请求消息  |
|  7  | 0x9207  |  √   |  √   |  申请交换指定车辆定位信息应答消息  |
|  8  | 0x9208  |  √   |  √   |  取消申请交换指定车辆定位信息应答消息  |
|  9  | 0x9209  |  √   |  √   |  补发车辆定位信息应答消息  |
|  10 | 0x920A  |  √   |  √   |  上报驾驶员身份识别信息请求消息  |
|  11 | 0x920B  |  √   |  √   |  上报车辆电子运单请求消息  |
|  12 | 0x920C  |  √   |  √   |  上报车辆车辆行驶路线请求(809-2019)  |
|  13 | 0x920D  |  √   |  √   |  车辆行驶线路请求应答(809-2019)  |

### 平台间信息交互类

#### 主链路平台间信息交互消息

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x1300  |  √   |  √   |  主链路平台间信息交互消息  |
|  2  | 0x1301  |  √   |  √   |  平台查岗应答消息(809补充协议文档)  |
|  3  | 0x1302  |  √   |  √   |  下发平台间报文应答消息(809补充协议文档)  |
|  4  | 0x1303  |  √   |  √   |  上传平台间消息补传请求消息(809-2019)  |

#### 从链路平台间信息交互消息

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x9300  |  √   |  √  | 从链路平台间信息交互消息  |
|  2  | 0x9301  |  √   |  √  | 平台查岗请求(809补充协议文档)  |
|  3  | 0x9302  |  √   |  √  | 下发平台间报文请求(809补充协议文档)  |
|  4  | 0x9303  |  √   |  √  | 下发平台间消息补传请求消息(809-2019)  |

### 车辆报警信息交互类

#### 主链路报警信息交互消息

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x1400  |  √   |  √  | 主链路平台间信息交互消息  |
|  2  | 0x1401  |  √   |  √  | 报警督办应答消息  |
|  3  | 0x1402  |  √   |  √  | 上报报警信息消息  |
|  4  | 0x1403  |  √   |  √  | 主动上报报警处理结果信息(809补充协议文档)  |

#### 从链路报警信息交互消息

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x9400  |  √   |  √   |  主链路平台间信息交互消息  |
|  2  | 0x9401  |  √   |  √   |  报警督办请求  |
|  3  | 0x9402  |  √   |  √   |  报警预警  |
|  4  | 0x9403  |  √   |  √   |  实时交换报警信息  |

### 车辆监管类

#### 主链路车辆监管消息

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x1500  |  √   |  √   | 主链路车辆监管消息  |
|  2  | 0x1501  |  √   |  √   | 车辆单向监听应答  |
|  3  | 0x1502  |  √   |  √   | 车辆拍照应答  |
|  4  | 0x1503  |  √   |  √   | 下发车辆报文应答  |
|  5  | 0x1504  |  √   |  √   | 上报车辆行驶记录应答(809补充协议文档)  |
|  6  | 0x1505  |  √   |  √   | 车辆应急接入监管平台应答消息  |

#### 从链路车辆监管消息

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x9500  |  √   |  √  | 从链路车辆监管消息  |
|  2  | 0x9501  |  √   |  √  | 车辆单向监听请求  |
|  3  | 0x9502  |  √   |  √  | 车辆拍照请求  |
|  4  | 0x9503  |  √   |  √  | 下发车辆报文请求  |
|  5  | 0x9504  |  √   |  √  | 上报车辆行驶记录请求 |
|  6  | 0x9505  |  √   |  √  | 车辆应急接入监管平台请求消息 |

### 车辆静态信息交换类

#### 主链路静态信息交换消息

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x1600  |  √   |  √  | 主链路静态信息交换消息  |
|  2  | 0x1601  |  √   |  √  | 补报车辆静态信息应答  |
|  3  | 0x1602  |  √   |  √  | 补报车辆行驶路线信息应答消息  |

#### 从链路静态信息交换消息

|序号|消息ID|完成情况|测试情况|消息体名称|
|:------:|:------:|:------:|:------:|:------:|
|  1  | 0x9600  |  √   |  √  | 从链路静态信息交换消息  |
|  2  | 0x9601  |  √   |  √  | 补报车辆静态信息应答  |

## 基于JT1078扩展的JT809消息协议

### JT809扩展协议消息对照表

#### 主链路动态信息交换消息

| 序号  | 消息ID        | 完成情况 | 测试情况 | 消息体名称                                     |
| :---: | :-----------: | :------: | :------: | :----------------------------:              |
| 1     | 0x1700        | √        | √        | 主链路时效口令交互消息                            |
| 2     | 0x1700_0x1701        | √        | √        | 时效口令上报消息(有疑问:数据体有问题)                     |
| 3     | 0x1700_0x1702        | √        | √        | 时效口令请求消息                     |
| 4     | 0x1800        | √        | √        | 主链路实时音视频交互消息                       |
| 5     | 0x1800_0x1801        | √        | √        | 实时音视频请求应答消息                  |
| 6     | 0x1800_0x1802        | √        | √        | 主动请求停止实时音视频传输应答消息                   |
| 7     | 0x1900        | √        | √        | 主链路远程录像检索                       |
| 8     | 0x1900_0x1901        | √        | √        | 主动上传音视频资源目录信息消息                       |
| 9     | 0x1900_0x1902        | √        | √        | 查询音视频资源目录应答消息                   |
| 10     | 0x1A00        | √        | √        | 主链路远程录像回放交互消息                       |
| 11     | 0x1A00_0x1A01        | √        | √        | 远程录像回放请求应答消息                       |
| 12     | 0x1A00_0x1A02        | √        | √        | 远程录像回放控制应答消息                   |
| 13     | 0x1B00        | √        | √        | 主链路远程录像下载交互消息                            |
| 14     | 0x1B00_0x1B01        | √        | √        | 远程录像下载请求应答消息                     |
| 15     | 0x1B00_0x1B02        | √        | √        | 远程录像下载通知消息                     |
| 16     | 0x1B00_0x1B03        | √        | √        | 远程录像下载控制应答消息                       |

#### 从链路动态信息交换消息

| 序号  | 消息ID        | 完成情况 | 测试情况 | 消息体名称                                     |
| :---: | :-----------: | :------: | :------: | :----------------------------: |
| 17     | 0x9700        | √        | √        | 从链路时效口令交互消息                  |
| 18     | 0x9700_0x9702        | √        | √        | 时效口令请求应答消息(有疑问:应该有应答结果)                |
| 19     | 0x9800        | √        | √        | 从链路实时音视频交互信息                       |
| 20     | 0x9800_0x9801        | √        | √        | 实时音视频请求消息                       |
| 21     | 0x9800_0x9802        | √        | √        | 主动请求停止实时音视频传输消息                   |
| 22     | 0x9900        | √        | √        | 从链路远程录像检索交互消息                       |
| 23     | 0x9900_0x9901        | √        | √        | 主动上传音视频资源目录信息应答消息                       |
| 24     | 0x9900_0x9902        | √        | √        | 查询音视频资源目录请求消息                   |
| 25     | 0x9A00        | √        | √        | 从链路远程录像回放交互消息                            |
| 26     | 0x9A00_0x9A01        | √        | √        | 远程录像回放请求消息                     |
| 27     | 0x9A00_0x9A02        | √        | √        | 远程录像回放控制消息                     |
| 28     | 0x9B00        | √        | √        | 从链路远程录像下载交互消息                       |
| 29     | 0x9B00_0x9B01        | √        | √        | 远程录像下载请求消息                  |
| 30     | 0x9B00_0x9B02        | √        | √        | 远程录像下载完成通知应答消息                   |
| 31     | 0x9B00_0x9B03        | √        | √        | 远程录像下载控制消息                       |

### 使用方法

```dotnet
IServiceCollection serviceDescriptors1 = new ServiceCollection();
serviceDescriptors1.AddJT809Configure()
                   .AddJT1078Configure();
```
