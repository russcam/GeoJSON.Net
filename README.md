#GeoJSON.NET [![NuGet Version](http://img.shields.io/nuget/v/GeoJSON.NET.svg?style=flat)](https://www.nuget.org/packages/GeoJSON.NET/) [![Build status](https://ci.appveyor.com/api/projects/status/lfxlj13sa5vk0l3y)](https://ci.appveyor.com/project/jbattermann/geojson-net)

GeoJSON.Net is a .NET library for the [GeoJSON v1.0 specificaton](http://geojson.org/geojson-spec.html) and it uses and provides [Newtonsoft Json.NET](http://json.codeplex.com) converters for serialization and deserialization of GeoJSON data.

##Installation
The easiest way to use GeoJSON.Net is to install the [GeoJSON.Net](https://www.nuget.org/packages/GeoJSON.Net/) NuGet package in to your project: 

`PM> Install-Package GeoJSON.Net`

## Usage

### Working with known geojson types

In cases where you know the geojson type you are dealing with, you can simply serialize and deserialize using Json.Net's `JsonSerializer` or `JsonConvert` classes:

#### Serialization

```c#
var polygon = new Polygon(new List<LineString>
{
    new LineString(new List<GeographicPosition>
    {
        new GeographicPosition(52.379790828551016, 5.3173828125),
        new GeographicPosition(52.36721467920585, 5.456085205078125),
        new GeographicPosition(52.303440474272755, 5.386047363281249, 4.23),
        new GeographicPosition(52.379790828551016, 5.3173828125)
    })
});

var json = JsonConvert.SerializeObject(polygon);
```
	
will assign the following json string to the `json` variable *(indentation added for clarity; the above call would actually result in json with no line breaks or spaces)*:

```javascript
{
    "type": "Polygon",
    "coordinates": [
        [
            [
                5.3173828125,
                52.379790828551016
            ],
            [
                5.456085205078125,
                52.36721467920585
            ],
            [
                5.386047363281249,
                52.303440474272755,
                4.23
            ],
            [
                5.3173828125,
                52.379790828551016
            ]
        ]
    ]
}
```

#### Deserialization

Given the above json string:

```c#
var polygon = JsonConvert.DeserializeObject<Polygon>("[above json string here]");
```

### Working with unknown/varying geojson types

In cases where the geojson types are not known or more likely, where the geojson types are varying, the `IGeometryObject` interface in conjunction with the `GeometryConverter` can be used:

#### Serialization

```c#
\\ perhaps this geometry is coming from a data source
IGeometryObject geometryObject = new Polygon(new List<LineString>
{
    new LineString(new List<GeographicPosition>
    {
        new GeographicPosition(52.379790828551016, 5.3173828125),
        new GeographicPosition(52.36721467920585, 5.456085205078125),
        new GeographicPosition(52.303440474272755, 5.386047363281249, 4.23),
        new GeographicPosition(52.379790828551016, 5.3173828125)
    })
});

var json = JsonConvert.SerializeObject(geometryObject);
```
	
#### Deserialization

Given the above json string:

```c#
var geometryObject = JsonConvert.DeserializeObject<IGeometryObject>("[above json string here]", new GeometryConverter());
```
`geometryObject` will be an instance of the geojson type defined by the top level `type` property in the geojson structure.

### Equality

All 

##News
Well it's probably best to check out the [commits](https://github.com/jbattermann/GeoJSON.Net/commits/master) what has been added over time.

## Contributing
Highly welcome! Just fork away and send a pull request.


##Thanks
This library would be NOTHING without its [contributors](https://github.com/jbattermann/GeoJSON.Net/graphs/contributors) - thanks so much!!

## Copyright

Copyright © 2014 Jörg Battermann & [Contributors](https://github.com/jbattermann/GeoJSON.Net/graphs/contributors)

## License

GeoJSON.Net is licensed under [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form"). Refer to [LICENSE.md](https://github.com/jbattermann/GeoJSON.Net/blob/master/LICENSE.md) for more information.

