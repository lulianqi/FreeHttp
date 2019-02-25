### 基本逻辑
![](https://github.com/lulianqi/MyFile/blob/master/2019-02-25_195524.png)
### 环境搭建
* Fiddler 扩展插件开发环境配置 请参考官方文档 https://docs.telerik.com/fiddler/Extend-Fiddler/ExtendWithDotNet （该文档已经详细说明了搭建及调试项目的过程）<br>
* Fiddler 对外开放接口可以参见《Lulu.Debugging with Fiddler》（书中不仅介绍Fiddler的起源，还纤细介绍了Fiddler的使用，其中就包括对外提供的扩展接口）<br>
*当前FreeHttp扩展插件开发使用.net framework 版本为4.5（您在配置开发环境时需要注意您调试引用的Fiddler 的版本，及您开发环境所支持的最高版本）<br>
<br>

### 基本结构
![](https://github.com/lulianqi/MyFile/blob/master/2019-02-25_195525.png)
>>1：AutoTest命名空间主要提供参数化数据的拾取及管理<br>
>>2：FiddlerHelper命名空间 提供与Fiddler篡改直接相关的功能<br>
>>3：FreeHttpControl命名空间提供UI界面及窗体操作逻辑<br>
>>4：HttpHelper命名空间提供对HTTP协议报文处理的功能<br>
>>5：MyHelper 命名空间提供公共的辅助工具<br>
>>6：WebService命名空间提供使网络服务的功能<br>
>>7：FiddlerFreeHttp继承至IAutoTamper，他是与FIddler数据交换的入口  ， FiddlerSessionTamper是FiddlerFreeHttp的工具类<br>


### FreeHttp使用说明
* 操作说明见https://www.cnblogs.com/lulianqi/p/10428551.html <br>
* 您可以根据自己的需要直接修改FreeHttp各部分的代码以改动或扩展FreeHttp的功能，使他更符合您的个性化需求。<br>
* 如果您发现了任何问题或是意见请请在https://github.com/lulianqi/FreeHttp/issues 直接提出 （您也可能通过邮箱联系mycllq@hotmail.com提出您的问题或建议）<br>
