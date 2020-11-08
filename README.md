[![Build Status](https://travis-ci.org/josh-perry/Tracery.Net.svg?branch=master)](https://travis-ci.org/josh-perry/Tracery.Net) [![NuGet version](https://badge.fury.io/nu/Tracery.Net.svg)](https://badge.fury.io/nu/Tracery.Net)

# Tracery.Net
Forked from Josh Perry's [.NET port](https://github.com/josh-perry/Tracery.Net) of Kate Compton's [Tracery](https://github.com/galaxykate/tracery). 

This version targets .NET standard 2.0.

## Minimal example
```cs
var grammar = new TraceryNet.Grammar(new FileInfo("grammar.json"));
var output = grammar.Flatten("#origin#");
Console.WriteLine(output);
```

Where grammar.json is:
```json
{
    "origin": "The #person# was feeling... #mood#",
    "person": ["girl", "dwarf", "cat", "dragon"],
    "mood": ["bashful", "dopey", "happy", "sleepy", "sneezy", "grumpy"]
}
```

Example outputs: 
```
The dwarf was feeling grumpy.
The girl was feeling sneezy.
The girl was feeling sleepy.
The dwarf was feeling grumpy.
The dragon was feeling dopey.
```

[See TraceryNetExample project for more](TraceryNetExample/Program.cs)

## Custom modifiers
```cs
var json = "{" +
           "    'origin': '#sentence.toUpper#'," +
           "    'sentence': 'hello cat'" +
           "}";

var grammar = new TraceryNet.Grammar(json);
grammar.AddModifier("toUpper", modifier);

var output = grammar.Flatten("#origin#");
```

Where modifier is something like this:
```cs
Func<string, string> modifier = delegate (string i)
{
    return i.ToUpper();
};
```

Output:
```
HELLO CAT
```

## YAML
YAML can be used as a source instead of JSON:
```yaml
--- 
origin: "#sentence#"
sentence: "#greeting# #place#"
place:
  - "world"
  - "galaxy"
  - "universe"
greeting:
  - "Hello"
  - "Hey"
  - "Sup"
```

## Status
| Feature                           | Status                   |
|-----------------------------------|--------------------------|
| Capitalize All                    | :heavy_check_mark:       |
| Capitalize                        | :heavy_check_mark:       |
| In Quotes                         | :heavy_check_mark:       |
| Comma                             | :heavy_check_mark:       |
| :honeybee: Speak                  | :heavy_check_mark:       |
| Pluralize                         | :heavy_check_mark:       |
| Past-tensifiy                     | :heavy_check_mark:       |
| Custom modifiers                  | :heavy_check_mark:       |
| Saving data & actions             | :heavy_check_mark:       |
