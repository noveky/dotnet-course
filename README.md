# .NET 架构程序设计课程

## 目录
- [第一次作业](#第一次作业)
- [第二次作业](#第二次作业)
- [第三次作业](#第三次作业)
- [第四次作业](#第四次作业)

## 课后作业

### 第一次作业

#### Hello, world!

在控制台中输出 `Hello, world!`

#### 素数因子分解

输入正整数，输出其质因数分解结果

> ![](第一次作业/运行截图/PrimeFactors-1.png)

#### 口算自动出题机

自动出 100 以内的加减法计算题，每道题限时并在提交时评分

- 倒计时结束时提交本题，展示答题是否正确，并自动下一题

> ![](第一次作业/运行截图/ProblemGenerator-1.png)

- 答题错误时显示红色

> ![](第一次作业/运行截图/ProblemGenerator-2.png)

- 完成所有题目后交卷，统计得分

> ![](第一次作业/运行截图/ProblemGenerator-3.png)

### 第二次作业

#### ATM 机模拟器

账户分为普通账户和信用账户，存款时以 30% 概率模拟坏钞异常，进行 10000.00 以上的大额取款时显示警告信息

- 账户验证

> ![](第二次作业/运行截图/1.png)

- 存取款

> ![](第二次作业/运行截图/2.png)

- 大额取款警告

> ![](第二次作业/运行截图/3.png)

### 第三次作业

#### 代码格式化与统计程序

对 C# 代码进行处理，去除 `//` 开头的注释，划分其中的英文单词，并统计词频

> 匹配单词的正则表达式：`((?<![0-9][A-Za-z]*)[A-Z]?[a-z]+)|((?<![0-9][A-Za-z]*)[A-Z]+(?![a-z]+))`
> 
> 例：
> > ```
> > abcDEFGhiJKL
> > AbcDefGHIJkl
> > 0xBCD8AB95
> > 1Aaa1 2aAa2 3aaA3
> > ```
> > 匹配到的单词：
> > ```
> > abc DEF Ghi JKL Abc Def GHI Jkl
> > ```

- 打开 `.cs` 文件

> ![](第三次作业/运行截图/1.png)

- 显示代码内容

> ![](第三次作业/运行截图/2.png)

- 去除注释，分词，统计词频

> ![](第三次作业/运行截图/3.png)

### 第四次作业

#### 简单文件浏览器程序

支持上层目录和历史记录跳转，改变文件列表视图

> 使用双向链表结点 `DirHistoryNode` 维护历史记录

- 展开目录结点

> ![](第四次作业/运行截图/1.png)

- 双击打开文件

> ![](第四次作业/运行截图/2.png)

- 通过下拉框访问历史记录，或按【←】【→】按钮在历史记录中跳转

> ![](第四次作业/运行截图/3.png)

- 更改显示方式

> ![](第四次作业/运行截图/4.png)