# 气溶胶数据处理软件流程

## 要求

读取 CSV 格式数据，数据的文件可以是一个或者多个，如果是多个，则需要一起导入进行处理。

在这个过程中，需要解决的问题是：

1. 完成文件的拼接；
2. 在文件上面加上文件名限制，作为日期数据导入参与计算；
   需要解析多文件
   多文件文件名名转化为各自的日期带入计算
3. 计算过程需要引入一些特殊的数学函数，要看一下有没有现成的轮子用；
4. 计算完成数据之后结果进行画图输出（记得是有一个控件可以完成这个功能的）。

## 读取 CSV 数据

读取 CSV 数据使用开源的 CsvHelper 组件进行，读取方式是字符串匹配得到属性值。

但是需要注意的是：读取的时候，CSV 文件需要是使用 UTF-8 编码，且头部无任何其他的东西。(e.g. 也就是如果你用 Microsoft 的记事本打开之后，这个再读取是会出错的，需要用 Notepad++ 重新打开转化为 UTF-8 编码😭，在这个读取上面就花了一下午时间研究为什么读不进)。

## 文件的拼接

## 文件名处理

### 解析单个文件路径

单个文件路径的解析可以通过调用 `System.IO` 下面的 `Path` 类下面定义的一系列静态方法解决。

`Path` 类包含可以用于解析某个给定路径的方法。与编写路径解析和文件名解析的代码相比，使用这些类要更加简单并且不容易出错。如果不使用这些类，在安全决策中手动解析例程，也有可能会给软件带来安全漏洞，用于解析的主要是五个方法。

- GetPathRoot
  该方法返回路径的根目录。如果路径中没有根目录，例如使用一个相对路径时，该方法返回一个空字符串，而不是 null
- GetDirectoryName
  该方法返回文件所在目录的完整路径
- GetFileName
  该方法返回文件名，包含文件的扩展名。如果路径中没有提供文件名，那么该方法返回一个空字符串，而不是 null
- GetExtension
  该方法返回文件的扩展名。如果没有提供文件的扩展名或者路径中没有文件，那么其返回一个空字符串，而不是 null
- GetFileNameWithoutExtension
  都不用讲了看名字就知道了

要注意，这些方法并不能确定驱动器、目录甚至文件是否存在或者运行于系统中。这些方法仅仅是字符串解析器，只要传递正确的字符串，就能解析出对应的文本。

### 参考

[详情见 MSDN 的 `System.IO.Path` 类下的说明。](https://docs.microsoft.com/zh-cn/dotnet/api/system.io.path?view=netframework-4.7.2)

### 解析多个文件路径

多个文件路径的解析是通过 `openFileDialog` 完成的。看代码

```csharp
//初始化 openFileDialog 类实例化对象 testDialog 
//使用 using 可以自动销毁对象
using (openFileDialog testDialog = new openFileDialog())
{
    //设置文全部文件格式都可以选择
    testDialog.Filter = "All Files (*.*)|*.*";
    //决定 Filter 决定的顺序从哪里开始，默认是1
    testDialog.FilterIndex = 1;
    //可以选择多个文件
    testDialog.Multiselect = true;

    if(testDialog.ShowDialog() == DiaologResult.OK)
    {
        string[] arrAllFiles = testDialog.FileNames;
    }
    else
    {
        arrAllFiles = string.empty;
    }
}
```

上面的代码可以得到多个文件的路径主要的作用语句就是。

```csharp
string[] arrAllFiles = terstDialog,FileNames;
```

FilterIndex  也就指的是下面这个东西。

![](.\img\读取多文件的FilterIndex解释.png)

读取结果也就是像这样，当然这个结果是需要用 `Path` 作解析之后得到的

![](.\img\读取多文件结果.png)

## 数值计算

## 绘图输出结果