# Types

## What are Types?

C# offers many built in 'types' that allow you to identify what exactly you are 
working with in regards to an object, string, integer, boolean etc..

Types are extrememly important in C# because everything essentially has a type. You have the ability to use 
a built in type, or create your own. As you get more familiar with the language, you begin to identify and use different
types as needed a bit more naturally then when you start out. 

## Numeric

### Integral types

Type  | Bytes | Range |
 ------------ | :-----------: | -----------: |
byte       | 1 (8 bits) | 0 to 255 |
short       | 2 (16 bits) | -32,768 to 32,767 |
int       | 4 (32 bits) | -2,147,483,648 to 2,147,483,647 |
long       | 8 (64 bits) | -9,233,372,036,854,775,808 to 9,233,372,036,854,775,808 |

** The 'int' type is the most commonly used type for a number. This is usually because it is what most 
developers are most familiar with. This does not mean though that you *should* always use the int type.

#### Signed/Unsigned Types

- **signed** - Signed types mean that the type has the capability to range from negative to positive (it can have a + or - sign in front of the number)
- **unsigned** - Unsigned types means that the type can only be in the positive. It is assumed that a number without a sign in the front is a positive. 

Type  | Bytes | Range |
 ------------ | :-----------: | -----------: |
sbyte       | 1 (8 bits) | -128 to +127 |
ushort       | 2 (16 bits) | 0 to 64,000 |
uint       | 4 (32 bits) | 0 to 4,294,967,295 |
ulong       | 8 (64 bits) | 0 to 18,446,744,073,709,551,615 |

Notice that `byte` turns into a *signed* type to allow for negative numbers. 

#### 'char' Type
`char` is short for character, but is still considered an itegral type. This is because behind the scenes the numerical representation of that 
character is stored as the type. The compiler knows to output an actual character when encountering `char`s 

Type  | Bytes | Range |
 ------------ | :-----------: | -----------: |
char       | 2 (16 bits) | U+0000 to U+FFFF (Unicode) |

### Floating Point Types
Floating point types store numbers with decimal places. There are 3 different 'Types' in C# that support integers with decimal places. 

Type  | Bytes | Range | Precision
 ------------ | :-----------: | :-----------: | -----------:
float       | 4 (32 bits) | -3.4 × 10<sup>38</sup> to +3.4 × 10<sup>38</sup> | 7-8 |
double       | 8 (64 bits) | ±5.0 × 10<sup>−324</sup> to ±1.7 × 10<sup>308</sup> | 15-16 |
decimal       | 16 (128 bits) | (-7.9 x 10<sup>28</sup> to 7.9 x 10<sup>28</sup>) / (10<sup>0</sup> to 10<sup>28</sup>) | 28-29 |

- *float*: `float pi = 3.1415926f;` OR `float pi = 3.1415926F;`
	- Note the "f"/"F" at the end. When typing out a *floating type literal* you must specify the type to tell the compiler to convert the double number into a float.
- *double*: when seeing a decimal number, the compiler assumes a double unless you specify differently (see decimal and float examples) 
- *decimal*: `decimal cash = 12.345m;` OR `decimal cash = 12.345M;`
	- Note the "m"/"M" at the end. Decimal is primarily used when working with money (hence the 'm').  hen typing out a *decimal type literal* you must specify the type to tell the compiler to convert the double number into a float.

## Non-Numeric

### Boolean
A `bool` is considered a truth value. This means that the value can hold *boolean literals* of true or false. Behind the scenes:
- 0 represents true 
- 1 represents false

You **cannot** assign a 0/1 to a bool. it must be true or false <br /> 

example: 
- `bool loveCats = true;` 
- `bool likesBirds = false;`

### String
A part from `int`, string is the next easiest type to remember. A *string* literal will hold any text you allocate within double quotes/
- `string greeting = "Hello, my name is Amanda";`


## Type Inference
In C# 3.0 a powerful new feature was released called type inference. Since every variable defined must have a type, the `var` type was introduced as just a general type that can be used for declaration of variables.
The cool thing about type inference is that the compiler is smart enough, given the context of the value, to determine the type that it should be. 

### Why use type inference?
A lot of developers prefer type inference because it's quicker to type and leaving the type declaration on the compiler can sometimes reduce the decision making process.
On contrary, many developers also feel that the usage of `var` reduces the code clarity and can cause some confusion with developers teamon what types are being used.  

### Example:
`var greeting = "Hello World";`

<hr />

## Casting
Sometimes it is required to do mathamatical equations of two different types of variables. When this happens it is usually helpful to have the ability to change
the original types to different types quickly (for example: changing a short to an int). This can be done through ***typecasting***. 

There are two different types of typecasting:
1. implicit casting - this happens without you knowing. The compiler does it itself. This is usually done when there is no risk of loss data
	- Example of implicit casting
	```csharp
	int a = 1001;
	long b = 1000001;
	long answer = a + b;
	```
2. explicit casting - you have to explicitly tell the type to change. 
	- Example of explicit casting: 
	```csharp
	 long myNumber = 20;
	 int answer = (int)myNumber
	```

