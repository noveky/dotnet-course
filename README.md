# .NET 架构程序设计课程

## 目录
- [第一次作业](#第一次作业)
- [第二次作业](#第二次作业)
- [第三次作业](#第三次作业)
- [第四次作业](#第四次作业)

## 课后作业

### 第一次作业

#### 1. Hello, world!

在控制台中输出 `Hello, world!`

#### 2. 素数因子分解

输入正整数，输出其质因数分解结果

> ![](%E7%AC%AC%E4%B8%80%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/PrimeFactors-1.png)

#### 3. 口算自动出题机

自动出 100 以内的加减法计算题，每道题限时并在提交时评分

- 倒计时结束时提交本题，展示答题是否正确，并自动下一题

> ![](%E7%AC%AC%E4%B8%80%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/ProblemGenerator-1.png)

- 答题错误时显示红色

> ![](%E7%AC%AC%E4%B8%80%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/ProblemGenerator-2.png)

- 完成所有题目后交卷，统计得分

> ![](%E7%AC%AC%E4%B8%80%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/ProblemGenerator-3.png)

### 第二次作业

WinForm ATM 机模拟器

账户分为普通账户和信用账户，存款时以 30% 概率模拟坏钞异常，进行 10000.00 以上的大额取款时显示警告信息

- 账户验证

> ![](%E7%AC%AC%E4%BA%8C%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/1.png)

- 存取款

> ![](%E7%AC%AC%E4%BA%8C%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/2.png)

- 大额取款警告

> ![](%E7%AC%AC%E4%BA%8C%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/3.png)

### 第三次作业

WinForm 代码格式化与统计程序

对 C# 代码进行处理，去除 `//` 开头的注释，划分其中的英文单词，并统计词频

> 匹配单词的正则表达式：`((?<![0-9][A-Za-z]*)[A-Z]?[a-z]+)|((?<![0-9][A-Za-z]*)[A-Z]+(?![a-z]+))`

- 打开 `.cs` 文件

> ![](%E7%AC%AC%E4%B8%89%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/1.png)

- 显示代码内容

> ![](%E7%AC%AC%E4%B8%89%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/2.png)

- 去除注释，分词，统计词频

> ![](%E7%AC%AC%E4%B8%89%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/3.png)

### 第四次作业

WinForm 简单文件浏览器程序

- 展开目录节点

> ![](%E7%AC%AC%E5%9B%9B%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/1.png)

- 双击打开文件

> ![](%E7%AC%AC%E5%9B%9B%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/2.png)

- 通过下拉框访问历史记录，或按【←】【→】按钮在历史记录中跳转

> ![](%E7%AC%AC%E5%9B%9B%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/3.png)

- 更改显示方式

> ![](%E7%AC%AC%E5%9B%9B%E6%AC%A1%E4%BD%9C%E4%B8%9A/%E8%BF%90%E8%A1%8C%E6%88%AA%E5%9B%BE/4.png)