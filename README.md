# range

This project is a .NET Core application.

This project provides a class which can be used to model a range of type Generic and has a helper method InRange which returns a boolean if the value provided is within the range provided.

##Usage

Add the package to your project(s):

Install-Package Range

To define a range of int:

bool inRange;

var range = new Savage.Range<int>(1, 10);

var f = range.Floor   // f =  1
var c = range.Ceiling // c = 10

inRange = range.InRange(0);  //inRange = false
inRange = range.InRange(1);  //inRange = true
inRange = range.InRange(5);  //inRange = true
inRange = range.InRange(10); //inRange = true
inRange = range.InRange(11); //inRange = false

As the class supports generics other types can be used, such as strings:

var range2 = new Savage.Range<string>("A", "F");

var f = range.Floor   // f = "A"
var c = range.Ceiling // c = "F"

inRange = range2.InRange("A"); //inRange = true
inRange = range2.InRange("C"); //inRange = true
inRange = range2.InRange("F"); //inRange = true
inRange = range2.InRange("G"); //inRange = false

or DateTime's:

var range3 = new Savage.Range<DateTime>(new DateTime(2016, 3, 1), new DateTime(2016, 10, 31));

var f = range.Floor   // f = DateTime(2016, 3, 1)
var c = range.Ceiling // c =DateTime(2016, 10, 31)

inRange = range3.InRange(new DateTime(2016, 2,28)); //inRange = false
inRange = range3.InRange(new DateTime(2016, 3, 1)); //inRange = true
inRange = range3.InRange(new DateTime(2016, 7, 1)); //inRange = true
inRange = range3.InRange(new DateTime(2016,10,31)); //inRange = true
inRange = range3.InRange(new DateTime(2016,11, 1)); //inRange = false
