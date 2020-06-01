# Size add or deduct
> Program that can add or deduct size. 

## Table of contents
* [General info](#general-info)
* [Screenshots](#screenshots)
* [Technologies](#technologies)
* [Setup](#setup)
* [Features](#features)
* [Status](#status)
* [Inspiration](#inspiration)
* [Contact](#contact)

## General info
Program is made in c#. I am so proud of this project as this is one of my first and hardest by then projects. So in this project you adding or deducting anz type of size (mm,cm,m,km) and as result you get one parsed size. Example, user input 1km + 30m and output is 1.03km or if he wants in m or cm he can choose. Feel free to clone or download this repo.


## Screenshots
![](https://github.com/MarkoVitkovic/csh-sizeAddDeduct/blob/master/prva.jpg)

## Technologies
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)

## Setup
1.Open Visual Studio 2019.</br>

2.On the start window, choose Create a new project.</br>
![](https://docs.microsoft.com/en-us/visualstudio/get-started/media/vs-2019/create-new-project-dark-theme.png?view=vs-2019)</br>
3.On the Create a new project window, enter or type console in the search box. Next, choose C# from the Language list, and then choose Windows from the Platform list.</br>

* After you apply the language and platform filters, choose the Console App (.NET Core) template, and then choose Next.</br>
![](https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/media/vs-2019/csharp-create-new-project-search-console-net-core-filtered.png?view=vs-2019)</br>
4.In the Configure your new project window, type or enter HelloWorld in the Project name box. Then, choose Create.</br>
![](https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/media/vs-2019/csharp-name-your-helloworld-project.png?view=vs-2019)</br>


## Learn More


To learn C#, check out the [C# docs](https://docs.microsoft.com/en-us/dotnet/csharp/).

## Code Examples
Code:</br>
`List<double> operandi = new List<double>();`</br>
			`List<char> operatori = new List<char>();`</br>
			`List<int> duzine = new List<int>();`</br>
			`int uku=0;`</br>
			`string unos , mj_fin;`</br>
			`double cm, mm, m, km;`</br>
			`Console.WriteLine("Please enter sizes wich you want to add(deduct).\n");`</br>
			`unos = Console.ReadLine();`</br>
			`char[] spearator = { '+', '-' };`</br>
			`String[] strlist = unos.Split(spearator, StringSplitOptions.RemoveEmptyEntries);`</br>
			`foreach (String s in strlist)`</br>
			`{`</br>
				`int size = s.Length;`</br>
				`duzine.Add(size);`</br>
				`if (s.TrimEnd(null).EndsWith("mm"))`</br>
				`{`</br>
				`	string a=s.Remove(s.LastIndexOf("m")-1,2);`</br>
				`	mm = Double.Parse(a);`</br>
				`	mm /= 1000;`</br>
				`	operandi.Add(mm);`</br>
				`	continue;`</br>
				`}`</br>

## Features
List of features ready and TODOs for future development
* Add/deduct size
* Output size in mm,m,cm,km (choose!)

To-do list:
* none

## Status
Project is: _finished_

## Inspiration
My most loved project! I did this as my final exam.

## Contact
Created by [Marko Vitkovic](https://github.com/MarkoVitkovic) - feel free to contact me!































