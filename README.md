# RJK.FeatureDependencies
A module for Orchard CMS that visualises the feature dependencies for a project

## Installation

### Option 1: Download the NuGet package

- This will soon be on NuGet, but for now you can download it from Releases on the GitHub repo
- On the command line, run `package install "Orchard.Modules.RJK.FeatureDependencies" <download location> /Version:1.0`

### Option 2: Clone the repo

- Clone the repo
- Copy the module from the `Modules` directory into your `Modules` directory.
- Add the project to your solution in Visual Studio

## Usage

- Enable the feature in the Modules section of the Admin area
- Navigate to http://yourdomain.com/dependencies
- use the optional `filter` querystring parameter to filter out modules.

## Example Graph

http://i.imgur.com/bsD2Vnj.png
