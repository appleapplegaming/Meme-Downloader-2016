﻿# Meme Downloader 2016

That name is just joking :)

Dependencies (handled by the program by the most part):

  - ffmpeg
  - ~~youtube-dlp~~ (soon)

This app downloads can download stuff from a subreddit of your choice and throws what it gets into a folder.

This app runs 32 threads by default, and is (sometimes) VERY resource hungry on memory, some processes might stay as zombies, that means, they don't die, examples are ffmpeg, that can prevent you from deleting the program 

How to make `config.josn`?

This is the default `config.json` configuration:

```
{
	"TargetSubReddit0": "shitposting",
	"TargetSubReddit1": "dankmemes",
	"SimultaneousDownload": true,
	"ThreadCount": 32
}
```
**TargetSubreddit**: This is the subreddit from where you want to get posts from <br>
**ThreadCount**: This is how many bots will run simultaneously, going over 32 is normally overkill

------------------

### **NOTES**:

 - After downloading dependencies the program will fail to run the bots, close and open again the program for it to work as intended

------------------

Credits:

Original Idea: [SmallPP420](https://github.com/SmallPP420)

------------------

Thanks to: 

TeNaihi for helping me test it :D

------------------


## NOTES FOR FORKERS

If you fork this repo you will need to add a repository secret named TEST with your github token as your value if u want to use the github ci script to build
