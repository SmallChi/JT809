# JT809协议

## 瞎逼逼

1. 该JT809协议是参考[MessagePack-CSharp](https://github.com/neuecc/MessagePack-CSharp)一款二进制序列化器，借鉴其思想，不得不说站在巨人的肩膀上搬砖就是爽歪歪。
2. 搜索了很多资源没有针对.NET开源的809协议库，难道做GPS行业的.NET很少人吗？可能是藏着，掖着<(￣3￣)>  <(￣3￣)>  <(￣3￣)> 。
3. 不得不说这GB的文档，太坑了。。。
4. 现在有了[JT808](https://github.com/SmallChi/GPSPlatform/blob/master/JT808.md)的基础，对JT809就只剩搬砖了。

## 前提条件

1. 掌握进制转换：二进制转十六进制；
2. 掌握BCD编码、Hex编码；
3. 掌握各种位移、异或；
4. 掌握常用反射；
5. 掌握快速ctrl+c、ctrl+v；
6. 掌握以上装逼技能，就可以开始搬砖了。

## JT809数据结构解析

### 数据包[JT809Package]

|头标识|数据头|数据体|CRC校验码|尾标识
|:------:|:------:|:------:|:------:|:------:|
|  BeginFlag  | JT809Header  |  JT809Bodies  | CRCCode | EndFlag |
|  5B  | - | - | - | 5D |

### 数据头[JT809Header]

|数据长度|报文序列号|业务数据类型|下级平台接入码|协议版本号标识|报文加密标识位|数据加密的密匙|
|:------:|:------:|:------:|:------:|:------:|:------:|:------:|
| MsgLength | MsgSN | MsgID | MsgGNSSCENTERID | Version |EncryptFlag | EncryptKey |

### 数据体[JT809Bodies]

> 根据对应业务数据类型：MsgID

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

> 业务数据类型 MsgID:从链路报警信息交互消息
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
    MsgID = JT809Enums.JT809BusinessType.DOWN_WARN_MSG,
    MsgGNSSCENTERID = 20180920,
};

jT809Package.Bodies = new JT809_0x9400
{
    VehicleNo="粤A12345",
    VehicleColor= JT809Enums.JT809VehicleColorType.黄色,
    SubBusinessType= JT809Enums.JT809SubBusinessType.DOWN_WARN_MSG_URGE_TODO_REQ,
};

JT809_0x9400_0x9401 jT809_0x9400_0x9401 = new JT809_0x9400_0x9401
{
    WarnSrc = JT809WarnSrc.车载终端,
    WarnType = JT809WarnType.疲劳驾驶报警,
    WarnTime = DateTime.Parse("2018-09-27 10:24:00"),
    SupervisionID = "123FFAA1",
    SupervisionEndTime = DateTime.Parse("2018-09-27 11:24:00"),
    SupervisionLevel = 3,
    Supervisor = "smallchi",
    SupervisorTel = "12345678901",
    SupervisorEmail = "123456@qq.com"
};

jT809Package.Bodies.JT809SubBodies = jT809_0x9400_0x9401;

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
Assert.Equal(JT809Enums.JT809BusinessType.DOWN_WARN_MSG, jT809Package.Header.MsgID);
Assert.Equal(new JT809Header_Version(1, 0, 0).ToString(), jT809Package.Header.Version.ToString());

//4.数据包体
JT809_0x9400 jT809_0X400 = (JT809_0x9400)jT809Package.Bodies;
Assert.Equal("粤A12345", jT809_0X400.VehicleNo);
Assert.Equal(JT809Enums.JT809VehicleColorType.黄色, jT809_0X400.VehicleColor);
Assert.Equal(JT809Enums.JT809SubBusinessType.DOWN_WARN_MSG_URGE_TODO_REQ, jT809_0X400.SubBusinessType);
Assert.Equal((uint)92, jT809_0X400.DataLength);

//5.子数据包体
JT809_0x9400_0x9401 jT809_0x9400_0x9401 = (JT809_0x9400_0x9401)jT809_0X400.JT809SubBodies;
Assert.Equal(JT809WarnSrc.车载终端, jT809_0x9400_0x9401.WarnSrc);
Assert.Equal(JT809WarnType.疲劳驾驶报警, jT809_0x9400_0x9401.WarnType);
Assert.Equal(DateTime.Parse("2018-09-27 10:24:00"), jT809_0x9400_0x9401.WarnTime);
Assert.Equal("123FFAA1", jT809_0x9400_0x9401.SupervisionID);
Assert.Equal(DateTime.Parse("2018-09-27 11:24:00"), jT809_0x9400_0x9401.SupervisionEndTime);
Assert.Equal(3, jT809_0x9400_0x9401.SupervisionLevel);
Assert.Equal("smallchi", jT809_0x9400_0x9401.Supervisor);
Assert.Equal("12345678901", jT809_0x9400_0x9401.SupervisorTel);
Assert.Equal("123456@qq.com", jT809_0x9400_0x9401.SupervisorEmail);

```

### 举个栗子3
``` data2
// 设置全局配置
JT809GlobalConfig.Instance.SetHeaderOptions(new JT809Configs.JT809HeaderOptions
{
    EncryptKey= 9999,
    MsgGNSSCENTERID= 20180920
});

// 根据业务类型创建对应包
JT809Package jT809Package = JT809BusinessType.DOWN_WARN_MSG.Create(new JT809_0x9400
{
    VehicleNo = "粤A12345",
    VehicleColor = JT809Enums.JT809VehicleColorType.黄色,
    SubBusinessType = JT809Enums.JT809SubBusinessType.DOWN_WARN_MSG_URGE_TODO_REQ,
    JT809SubBodies = new JT809_0x9400_0x9401
    {
        WarnSrc = JT809WarnSrc.车载终端,
        WarnType = JT809WarnType.疲劳驾驶报警,
        WarnTime = DateTime.Parse("2018-09-27 10:24:00"),
        SupervisionID = "123FFAA1",
        SupervisionEndTime = DateTime.Parse("2018-09-27 11:24:00"),
        SupervisionLevel = 3,
        Supervisor = "smallchi",
        SupervisorTel = "12345678901",
        SupervisorEmail = "123456@qq.com"
    }
});
var hex = JT809Serializer.Serialize(jT809Package);
```

## NuGet安装

| Package Name |  Version | Downloads
|--------------|  ------- | ----
| JT809 | ![](https://img.shields.io/nuget/v/JT809.svg) | ![](https://img.shields.io/nuget/dt/JT809.svg)

Install-Package JT809

## 使用BenchmarkDotNet性能测试报告（只是玩玩，不能当真）

``` ini
BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.228 (1803/April2018Update/Redstone4)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  Job-FMFELU : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3132.0
  Job-TADNYV : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT

Platform=AnyCpu  Server=True
```

|                                  Method | Runtime |     Toolchain |      N |         Mean |      Error |     StdDev |      Gen 0 |    Allocated |
|---------------------------------------- |-------- |-------------- |------- |-------------:|-----------:|-----------:|-----------:|-------------:|
| **JT809_0x9400_0x9401_Package_Deserialize** |     **Clr** |       **Default** |    **100** |     **3.274 ms** |  **0.0603 ms** |  **0.0535 ms** |    **82.0313** |    **507.41 KB** |
|   JT809_0x9400_0x9401_Package_Serialize |     Clr |       Default |    100 |     3.863 ms |  0.0314 ms |  0.0293 ms |    82.0313 |    522.64 KB |
| JT809_0x9400_0x9401_Package_Deserialize |    Core | .NET Core 2.1 |    100 |     2.445 ms |  0.0402 ms |  0.0376 ms |          - |    464.89 KB |
|   JT809_0x9400_0x9401_Package_Serialize |    Core | .NET Core 2.1 |    100 |     2.789 ms |  0.0326 ms |  0.0272 ms |          - |    466.45 KB |
| **JT809_0x9400_0x9401_Package_Deserialize** |     **Clr** |       **Default** |  **10000** |   **329.457 ms** |  **1.6247 ms** |  **1.2685 ms** |  **8000.0000** |  **50808.81 KB** |
|   JT809_0x9400_0x9401_Package_Serialize |     Clr |       Default |  10000 |   386.584 ms |  2.2065 ms |  1.9560 ms |  8000.0000 |  52296.78 KB |
| JT809_0x9400_0x9401_Package_Deserialize |    Core | .NET Core 2.1 |  10000 |   239.150 ms |  1.6893 ms |  1.4975 ms |          - |  46495.02 KB |
|   JT809_0x9400_0x9401_Package_Serialize |    Core | .NET Core 2.1 |  10000 |   275.206 ms |  2.5906 ms |  2.4233 ms |          - |  46651.27 KB |
| **JT809_0x9400_0x9401_Package_Deserialize** |     **Clr** |       **Default** | **100000** | **3,253.840 ms** |  **9.0636 ms** |  **8.4781 ms** | **82000.0000** | **507671.31 KB** |
|   JT809_0x9400_0x9401_Package_Serialize |     Clr |       Default | 100000 | 4,070.297 ms | 79.1599 ms | 94.2342 ms | 85000.0000 | 522556.27 KB |
| JT809_0x9400_0x9401_Package_Deserialize |    Core | .NET Core 2.1 | 100000 | 2,425.372 ms | 37.3067 ms | 34.8967 ms |  2000.0000 | 464875.67 KB |
|   JT809_0x9400_0x9401_Package_Serialize |    Core | .NET Core 2.1 | 100000 | 2,823.721 ms | 42.6518 ms | 39.8965 ms |  2000.0000 | 466438.17 KB |

## JT809协议消息对照表

### 链路管理类

#### 主链路

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1   | 0x1001  |  √  | 主链路登录请求消息 |  
|  2   | 0x1002  |  √  | 主链路登录应答消息 |  
|  3   | 0x1003  |  √  | 主链路注销请求消息 |  
|  4   | 0x1004  |  √  | 主链路注销应答消息 |  
|  5   | 0x1005  |  √  | 主链路连接保持请求消息 |
|  6   | 0x1006  |  √  | 主链路连接保持应答消息 |
|  7   | 0x1007  |  √  | 主链路断开通知消息  |
|  8   | 0x1008  |  √  | 下级平台主动关闭链路通知消息  |

#### 从链路

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x9001  |  √  | 从链路连接请求消息  |
|  2  | 0x9002  |  √  | 从链路连接应答消息  |
|  3  | 0x9003  |  √  | 从链路注销请求消息  |
|  4  | 0x9004  |  √  | 从链路注销应答消息  |
|  5  | 0x9005  |  √  | 从链路连接保持请求消息  |
|  6  | 0x9006  |  √  | 从链路连接保持应答消息  |
|  7  | 0x9007  |  √  | 从链路断开通知消息 |
|  8  | 0x9008  |  √  | 上级平台主动关闭链路通知消息 |

### 信息统计类

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x9101  |  √  |接收定位信息数量通知消息  |

### 车辆动态信息交换

#### 主链路动态信息交换消息

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x1200  |  √   |  主链路动态信息交换消息  |
|  2  | 0x1201  |  √   |  上传车辆注册信息  |
|  3  | 0x1202  |  √   |  实时上传车辆定位信息  |
|  4  | 0x1203  |  √   |  车辆定位信息自动补报  |
|  5  | 0x1205  |  √   |  启动车辆定位信息交换应答消息  |
|  6  | 0x1206  |  √   |  结束车辆定位信息交换应答消息  |
|  7  | 0x1207  |  √   |  申请交换指定车辆定位信息请求消息  |
|  8  | 0x1208  |  √   |  取消交换指定车辆定位信息请求  |
|  9  | 0x1209  |  √   |  补发车辆定位信息请求  |
|  10 | 0x120A  |  √   |  上报车辆驾驶员身份识别信息应答  |
|  11 | 0x120B  |  √   |  上报车辆电子运单应答  |
|  12 | 0x120C  |  √   |  主动上报驾驶员身份信息  |
|  13 | 0x120D  |  √   |  主动上报车辆电子运单信息  |

#### 从链路动态信息交换消息

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x9200  |  √   |  从链路动态信息交换消息  |
|  2  | 0x9202  |  √   |  交换车辆定位信息消息  |
|  3  | 0x9203  |  √   |  车辆定位信息交换补发消息  |
|  4  | 0x9204  |  √   |  交换车辆静态信息消息  |
|  5  | 0x9205  |  √   |  启动车辆定位信息交换请求消息  |
|  6  | 0x9206  |  √   |  结束车辆定位信息交换请求消息  |
|  7  | 0x9207  |  √   |  申请交换指定车辆定位信息应答消息  |
|  8  | 0x9208  |  √   |  取消申请交换指定车辆定位信息应答消息  |
|  9  | 0x9209  |  √   |  补发车辆定位信息应答消息  |
|  10 | 0x920A  |  √   |  上报驾驶员身份识别信息请求消息  |
|  11 | 0x920B  |  √   |  上报车辆电子运单请求消息  |

### 平台间信息交互类

#### 主链路平台间信息交互消息

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x1300  |  √   |  主链路平台间信息交互消息  |
|  2  | 0x1301  |  √   |  平台查岗应答消息  |
|  3  | 0x1302  |  √   |  下发平台间报文应答消息  |

#### 从链路平台间信息交互消息

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x9300  |  √   |  从链路平台间信息交互消息  |
|  2  | 0x9301  |  √   |  平台查岗请求  |
|  3  | 0x9302  |  √   |  下发平台间报文请求  |

### 车辆报警信息交互类

#### 主链路报警信息交互消息

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x1400  |  √   |  主链路平台间信息交互消息  |
|  2  | 0x1401  |  √   |  报警督办应答消息  |
|  3  | 0x1402  |  √   |  上报报警信息消息  |
|  4  | 0x1403  |  √   |  主动上报报警处理结果信息  |

#### 从链路报警信息交互消息

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x9400  |  √   |  主链路平台间信息交互消息  |
|  2  | 0x9401  |  √   |  报警督办请求  |
|  3  | 0x9402  |  √   |  报警预警  |
|  4  | 0x9403  |  √   |  实时交换报警信息  |

### 车辆监管类

#### 主链路车辆监管消息

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x1500  |  √   |  主链路车辆监管消息  |
|  2  | 0x1501  |  √   |  车辆单向监听应答  |
|  3  | 0x1502  |  √   |  车辆拍照应答  |
|  4  | 0x1503  |  √   |  下发车辆报文应答  |
|  5  | 0x1504  |  √   |  上报车辆行驶记录应答  |
|  6  | 0x1505  |  √   |  车辆应急接入监管平台应答消息  |

#### 从链路车辆监管消息

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x9500  |  √   |  从链路车辆监管消息  |
|  2  | 0x9501  |  √   |  车辆单向监听请求  |
|  3  | 0x9502  |  √   |  车辆拍照请求  |
|  4  | 0x9503  |  √   |  下发车辆报文请求  |
|  5  | 0x9504  |  √   |  上报车辆行驶记录请求  |
|  6  | 0x9505  |  √   |  车辆应急接入监管平台请求消息  |

### 车辆静态信息交换类

#### 主链路静态信息交换消息

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x1600  |  √   |  主链路静态信息交换消息  |
|  2  | 0x1601  |  √   |  补报车辆静态信息应答  |

#### 从链路静态信息交换消息

|序号|消息ID|完成情况|消息体名称|
|:------:|:------:|:------:|:------:|
|  1  | 0x9600  |  √   |  从链路静态信息交换消息  |
|  2  | 0x9601  |  √   |  补报车辆静态信息应答  |