CSC Rule set/ideas

Variables:
var varname = value
ex :

	var a = 10 
	var a,b = 1 # multiple vars 1 value
	var a,b = 1,2 # multiple vars multiple values

When having more then one value you must have a unique value for each variable in the line

const is a keyword that determines if a variable is a constant
ex:

	const a = 0

Indentation:

Curly Brackets are used to signify indentation meaning anything inbetween curly brackets will be indented
ex:

	classname()
    	{
        	abc()
        	{
        	...
        	}
    	}
	
	classname(){abc(){}}

";" is used to indicate EOF (end of line) 

Types:

    short: number values from -32,768 to 32,767
    int: number values from -2^31+1 to +2^31-1
    float : allows usage of decimal numbers
    str: A string of a characters
    bool: true or false values
    list

types can be converted like so:

	var varout = 0
	var varin = "1"
	varout = varin.int()
	varout = int(varin)


Operators:

	Arithemetic operators:

		Addition: + ; a+b
		Subtraction: - ; a-b
		Multiplication: * ; a*b
		Division: / ; a/b
		Modulus: % ; a % b # returns the remainder of a division
		Exponentiation: ** ; a**b
		Floor division: //; a//b #returns the floor division of 2 numbers

	Assignement operators:

		= : a=1 #Sets a value
		++ : a++ #Increments a variable by 1
		-- : a-- #Decreases a variable by 1
		-= : a -= 3 #Decreases a variable by a chosen number and assigns the value
		+= : a += 3 #Increases a variable by a chosen number and assigns the value
		/= : a /=3 #Divides a variable by a chosen number and assigns the value
		*= : a *= 3 #Multiplies a variable by a chosen number and assigns the value
		%= : a %= 3 # Gets the division remainder and assigns it to variable by a chosen number
		**= : a**=3 Applies exponation to the variable by a chosen number and assigns it



	Boolean operators:
		AND: & , and ; true & true , true and true
		OR: | , or ; true | true , true or true
		NOT: ~ , not ; ~ true , not true
		XOR: ^ ; true ^ true

Command line reading and writing will be achieved with print() and input() with input having a prompt argument

ex:

	var a = 5;
	var prompt = input("insert number").int();
	print(a+5);
	CONSOLE OUTPUT
	--<5
	-->10

Strings

String concatination:

	var a = "a";
	var b "b";
	print(a+b);
	CONSOLE OUTPUT
	-->ab

Lists


Lists are created using []

Multidemension lists are nested lists

Lists can have a determined size using .size()

	ex:
	var list = [1,a,true]; #Normal list
	const list = [1,a,true]; #an imutable list
	var list = [1,2,3].size(3); #list with size
	var list = [[1,2],[1,2],[1,2]].size(3,2); #nested list with multiple sizes
	var list = [[1,2..n],[1,2..n],[1,2..n]].size(3); #nested list with a single size

Data is added to lists using .append() this will add data on the back of the array a reverse of this is .apppend_back()

Indexes are acessed by using [] after the variable name

indecies start at 0
Ex:

	a = [1,2,3];
	print(a[0]);
	CONSOLE  OUTPUT:
	-->1


Conditional statements:

Conditional statemnets can be created using if,else,elif


If:

If statements only allow execution of the indented code if the condition is true
ex:

	if(condition)
	{
    	#do stuff
	}


Else:

else statements only execute if the condition of a if statement or elif is false

else statements require a if statement

ex:

	if(condition)
	{
    	#do stuff
	}
	else
	{
    	#do stuff
	}


Elif:

elif statements only execute if the if statement is false and the condition inside the elif statement is true

they are equivilent to using else if

elif statements require a if statement

ex:

	if(condition)
	{
    	#do stuff
	}
	elif(condition)
	{
    	#do stuff
	}
	else
	{
    	#do stuff
	}

Looping:

Looping can be acheived with While,For

While:

While loops execute a piece of code while the condition inside the statement is true:

ex:

	while(condition)
	{
    	#do stuff
	}


For:

For loops will go through and get each element in a list/iterable stoping when it has gone through all list/iterable elements:
ex:

	for(item in list)
	{
    	#do stuff
	}

range() can be used in conjunction with for loops to create a loop with limited cycles

range() generates a list with the numbers inbetween the starting arguments and the ending arguments
ex:

	for(i in range(start,stop))
	{
    	#do stuff
	}	
