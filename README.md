﻿# KeesTalksTech Gallery Repository

This repository containers a lot of code samples for articles on my blog.
It is easier to keep the code up to date when all of the items are grouped.

## 1. Dependency injection (with IOptions) in Console Apps in .NET

When you are used to building web applications, you kind of get hooked to the 
ease of Dependency Injection (DI) and the way settings can be specified in a 
JSON file and accessed through DI (``IOptions<T>``). It's only logical to 
want the same features in your Console app.

- <a href="1.dependency-injection-with-ioptions-in-console-apps">1.dependency-injection-with-ioptions-in-console-apps</a>
- <a href="https://keestalkstech.com/2018/04/dependency-injection-with-ioptions-in-console-apps-in-dotnet/">Dependency injection (with IOptions) in Console Apps in .NET</a>


## 2. Simple JWT Access Policies for API security in .NET

Services can use their private key to communicate with our service.
We can configure the access for each issuer using standard .NET claims.

- <a href="2.simple-jwt-access-policies-for-api-security-in-net">2.simple-jwt-access-policies-for-api-security-in-net</a>
- <a href="https://keestalkstech.com/2024/11/simple-jwt-access-policies-for-api-security-in-net/">Simple JWT Access Policies for API security in .NET</a>

## 3. Options Injection

Options themselves can be collections as well. This
project shows how to use a `Dictionary<string, string>` and a
`List<string>` as base classes for options. Both are supported
by default.

- <a href="3.option-injection">3.option-injection</a>

## 4. .NET Console Application with injectable commands (System.CommandLine preview)

How to use `System.CommandLine` to build a CLI with commands and 
dependency injection.

- <a href="4.command-line-di-poc">4.command-line-di-poc</a>

## 5. Roman Numerals
Parsing Roman Numerals in C# is a good way to explore
(implicit) operator overloading.

- <a href="5.roman-numerals">5.roman-numerals</a>
- <a href="https://keestalkstech.com/2017/08/parsing-roman-numerals-using-csharp/">Parsing Roman Numerals using C#</a>
- <a href="https://keestalkstech.com/2017/08/calculations-with-roman-numerals-in-csharp/">Calculations with Roman Numerals using C#</a>

## 6. Handlebars.Net & JSON templates

I ❤️ Handlebars! So I was very very very happy to see that Handlebars was ported to .NET! 
It is a mega flexible templating engine as it can easily be extended. I'm working on a 
project where I need to parse objects via JSON templates to JSON strings. This blog will 
show how to instruct Handlebars to parse into JSON and add some nice error messages 
if your template fails.

- <a href="6.handlebars">6.handlebars</a>
- <a href="https://keestalkstech.com/2022/09/handlebars-net-json-templates/">Handlebars.Net & JSON templates</a>
- <a href="https://keestalkstech.com/2022/09/handlebars-net-fun-with-flags/">Handlebars.Net: Fun with [Flags]</a>
