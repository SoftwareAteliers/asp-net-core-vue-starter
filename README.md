# ASP.NET Core Vue Starter

The repository contains an ASP.NET Core + Vue.js starter template for both CLI and GUI. The template is created by Vue CLI 3.0 with a new plugin based architecture allowing developers to interactively scaffold a new project with just a one command.

---

## Table of Contents

* [Features](#features)
* [Used Technology Stack](#used-technology-stack)
* [Prerequisites](#prerequisites)
* [Getting Started](#getting-started)

## Features

* Hot module replacement
* Code-splitting
* Tree-shaking
* ES2017 transpilation
* Long term caching and so on

## Used Technology Stack

**ASP.NET Core 2.1:**

* Web.API
* JavaScript Services middleware to integrate with client app

**Vue.js with CLI 3.0 supporting optional integrations:**

* TypeScript
* Progressive Web App
* Vue Router & Vuex (State Store)
* Linting, unit testing, E2E testing
* 3rd party component frameworks (Vuetify, Vue Bootstrap etc.)
* publish your personal/enterprise plugin and so on...

## Prerequisites

* [.NET Core](https://www.microsoft.com/net/download/windows)
* [NodeJS](https://nodejs.org/) >= 8.9
* Your favourite editor (I prefer [VS Code](https://code.visualstudio.com/)), or VS 2017

---

## Getting started

* Clone this repository `git clone https://github.com/SoftwareAteliers/asp-net-core-vue-starter`
* Restore client side dependencies by running `npm install` in /ClientApp folder

You have two choices when it come at how your preffer to run it. You can either use the command line or the build-in run command.

### 1. Using the command line

> Normally we would run `dotnet run` command to run ASP.NET application and Microsoft ASP.NET Core JavaScriptServices middleware would start a new process for client side application, but middleware does not support Vue CLI 3 out-of-the-box right now, there's a [pull request](https://github.com/aspnet/JavaScriptServices/pull/1726) waiting to be merged.

For now:

* Run the Vue app in /asp-net-core-vue-starter/ClientApp folder with `npm run serve`
* Run the .NET application using `dotnet run`

### 2. Using the built-in run command

* Run the Vue app in /asp-net-core-vue-starter/ClientApp folder with `npm run serve`
* Run the application in VSCode or Visual Studio 2017 by hitting `F5`

## View your application running

Browse to [http://localhost:5000](http://localhost:5000)

## Recommended plugin for debugging VueJS

* Get Chrome DevTools for VueJS [here](https://chrome.google.com/webstore/detail/vuejs-devtools/nhdogjmejiglipccpnnnanhbledajbpd)

---

## Issues and Contribution

Want to file a bug, contribute some code, or improve documentation? Excellent! Please make sure to check existing issues before opening a new one.

---

## License

[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](/content/LICENSE)

Copyright &copy; 2018 [Software Ateliers](https://github.com/SoftwareAteliers)

## Where to find me

Medium: [Software Ateliers](https://medium.com/software-ateliers) | Twitter: [@SAteliers](https://twitter.com/SAteliers)