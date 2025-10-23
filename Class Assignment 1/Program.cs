//Class assignment of .NET Framework using C# (MCAE0402) 



//Q1.Imagine you are explaining the .NET framework architecture to a colleague unfamiliar with the framework. 
//    How would you break down the architecture and its components,
//    such as the CLR, FCL, and the application domains? Provide a structured explanation. 


//solution:- 


| Concept | Demonstrated By | Description |
| ---------------------- | ------------------------------- | ---------------------------------------------------- |
| **CLR * *                | Object creation, `GC.Collect()` | CLR manages memory and object lifecycle.             |
| **FCL**                | `System.IO.File.WriteAllText()` | Using library classes from .NET FCL.                 |
| **Application Domain** | `AppDomain.CurrentDomain`       | Shows the isolated environment of the app.           |
| **Language + IL**      | Comments and runtime behavior   | Code written in C# is compiled to IL and run by CLR. |



//Q2.In a team meeting, you are asked to explain key .NET framework runtime concepts like 
//    the Common Language Runtime (CLR), Common Type System (CTS), and Common Language Specification (CLS). 
//    How would you present these to ensure clarity and relevance to the team's work? 



//solution:-

| Concept |         Full Form |                             Purpose |                                      Example |
| ------- | ----------------------------- | ----------------------------------------------- | ---------------------------------- |
| **CLR * * | Common Language Runtime       | Executes code and manages runtime services      | Memory management, JIT compilation |
| **CTS** | Common Type System            | Defines how data types are represented and used | `int` = `System.Int32`             |
| **CLS** | Common Language Specification | Ensures language interoperability               | C# library usable in VB.NET        |





//Q3.You are developing a large-scale application and need to explain to a junior developer how assemblies are used
//    in .NET framework to organize and deploy the application.Provide an explanation of assemblies and include an 
//    example scenario where multiple assemblies are used. 

//solution:-

An Assembly is the building block of a .NET application.
It is a compiled output (like .exe or .dll) that contains:

IL(Intermediate Language) code

    | Type | Description | Example |
| ---------------------- | ------------------------------------------------------------------------------------ | ------------------------------------------- |
| **Private Assembly * *   | Used by a single application.                                                        | A DLL used only inside your project folder. |
| **Shared Assembly**    | Can be used by multiple applications, usually placed in GAC (Global Assembly Cache). | `System.Data.dll`                           |
| **Satellite Assembly** | Contains localized resources for different languages or regions.                     | `AppResources.en-US.dll`                    |

| Assembly Name            | Responsibility |
| ------------------------ | --------------------------------------------- |
| `ECommerceApp.exe`       | Main application(UI layer) |
| `ECommerce.Data.dll`     | Data Access(Database connectivity) |
| `ECommerce.Business.dll` | Business logic(Validation, Calculations) |
| `ECommerce.Utility.dll`  | Helper classes(Logging, File handling, etc.) |



//Q.4  In your project, you notice a developer struggling to organize classes and methods 
//properly. How would you explain the concept of namespaces in .NET framework 
//and demonstrate how they are used to avoid naming conflicts in large projects? 


//Solution





In the .NET Framework, a namespace is like a container or folder that helps organize classes, interfaces, enums, and other types logically.

> It prevents naming conflicts between classes that have the same name but serve different purposes.

  Why Namespaces Are Useful

Avoid naming conflicts — Two classes can have the same name if they belong to different namespaces.

Improve code organization — Related classes are grouped together logically.

Easier code maintenance — Large projects stay structured and readable.

Control visibility — You can control what’s accessible through using directives.


>> Example Demonstration

Let’s say you have two teams — one working on Customer Management and another on Order Management.
Both teams might create a class named Manager, but they can be placed in different namespaces.

// Customer related classes
namespace CompanyApp.CustomerManagement
{
    public class Manager
    {
        public void DisplayCustomer()
        {
            Console.WriteLine("Customer Manager class");
        }
    }
}

// Order related classes
namespace CompanyApp.OrderManagement
{
    public class Manager
    {
        public void DisplayOrder()
        {
            Console.WriteLine("Order Manager class");
        }
    }
}


Now, in your main program, you can use both classes without conflict:

using System;
using CompanyApp.CustomerManagement;
using CompanyApp.OrderManagement;

class Program
{
    static void Main()
    {
        // Using fully qualified names to avoid confusion
        var customerManager = new CompanyApp.CustomerManagement.Manager();
        customerManager.DisplayCustomer();

        var orderManager = new CompanyApp.OrderManagement.Manager();
        orderManager.DisplayOrder();
    }
}



//Q5.During a code review, a developer confuses primitive types with reference types 
//in their application. How would you explain the difference between primitive 
//types and reference types? 

//Solution


Concept Explanation:

In C#, primitive types are basic built-in types that hold their value directly in memory (e.g., int, float, char, bool).
Reference types, on the other hand, store a reference(memory address) that points to the actual data stored in the heap(e.g., class, array, string, object).


Example:

using System;

class PrimitiveReferenceDemo
{
    static void Main()
    {
        // Primitive type (value is stored directly)
        int num1 = 10;
        int num2 = num1;
        num2 = 20;

        Console.WriteLine($"Primitive: num1 = {num1}, num2 = {num2}");

        // Reference type (stores a reference to an object)
        string s1 = "Hello";
        string s2 = s1;
        s2 = "World";

        Console.WriteLine($"Reference: s1 = {s1}, s2 = {s2}");
    }
}



//Q.6 While refactoring a piece of C# code, you notice both value types and reference 
//types are being used incorrectly. Explain the difference between value types and 
//reference types in C#, and provide examples to clarify their behaviour in memory.


//Solution



//Concept:

Value types: Store actual data on the stack(e.g., int, float, bool, struct).
Reference types: Store reference(memory address) on the heap(e.g., class, string, array).

 Example:

using System;

class ValueReferenceDemo
{
    static void Main()
    {
        int x = 5;
        int y = x; // Copy created
        y = 10;
        Console.WriteLine($"Value Types: x = {x}, y = {y}");

        Person p1 = new Person { Name = "Alice" };
        Person p2 = p1; // Both refer to the same object
        p2.Name = "Bob";
        Console.WriteLine($"Reference Types: p1.Name = {p1.Name}, p2.Name = {p2.Name}");
    }
}

class Person
{
    public string Name;
}

// Output:
//Value Types: x = 5, y = 10
//Reference Types: p1.Name = Bob, p2.Name = Bob


//[Q7] You are tasked with creating a method that demonstrates both implicit and 
//explicit type conversions. Write a program in C# that converts an int to a double 
//implicitly and a double to an int explicitly, explaining each step in your code. 

//Solution

using System;
using System.Security.Policy;

class TypeConversion
{
    static void Main()
    {
        int num = 10;
        // Implicit conversion: int → double (no data loss)
        double d = num;
        Console.WriteLine($"Implicit Conversion: int {num} → double {d}");

        double val = 15.67;
        // Explicit conversion: double → int (possible data loss)
        int i = (int)val;
        Console.WriteLine($"Explicit Conversion: double {val} → int {i}");
    }
}

// Explanation:
//Implicit: Compiler does it automatically(safe conversion).
//Explicit: Done manually using cast operator (type).


//[Q8] A junior developer asks for help writing a program to determine whether a 
//number is positive, negative, or zero. Use if-else statements to write this program 
//in C#, and explain the logic behind the code.


//Solution

using System;

class NumberCheck
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n > 0)
            Console.WriteLine("Positive");
        else if (n < 0)
            Console.WriteLine("Negative");
        else
            Console.WriteLine("Zero");
    }
}

// Explanation:
//Uses if-else to test numeric comparisons in sequence.


//  [Q9].
//    You are explaining control flow constructs to a new hire. Use a switch-case 
//construct to explain how it works in C#. Illustrate the use of this construct by 
//writing a program that takes a number (1-5) and prints the corresponding 
//weekday. You are explaining control flow constructs to a new hire. Use a switch-case 
//construct to explain how it works in C#. Illustrate the use of this construct by 
//writing a program that takes a number (1-5) and prints the corresponding 
//weekday. 


//Solution

using System;
using static System.Net.Mime.MediaTypeNames;

class WeekdaySwitch
{
    static void Main()
    {
        Console.Write("Enter a number (1–5): ");
        int day = Convert.ToInt32(Console.ReadLine());

        switch (day)
        {
            case 1: Console.WriteLine("Monday"); break;
            case 2: Console.WriteLine("Tuesday"); break;
            case 3: Console.WriteLine("Wednesday"); break;
            case 4: Console.WriteLine("Thursday"); break;
            case 5: Console.WriteLine("Friday"); break;
            default: Console.WriteLine("Invalid number!"); break;
        }
    }
}

//Explanation:
//The switch statement tests a single variable against multiple cases.
//break prevents fall-through to the next case.


//  [Q10].
//    You are mentoring a developer on decision constructs in C#. Demonstrate how to 
//use nested if-else and switch-case statements together by writing a program that 
//checks a number and prints whether it is even/odd and whether it falls into 
//specific ranges (e.g., 0-10, 11-20)You are mentoring a developer on decision constructs in C#. Demonstrate how to 
//use nested if-else and switch-case statements together by writing a program that 
//checks a number and prints whether it is even/odd and whether it falls into 
//specific ranges (e.g., 0-10, 11-20)


//Solution

using System;

class NestedDecision
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        // Check even/odd
        if (num % 2 == 0)
            Console.WriteLine($"{num} is Even");
        else
            Console.WriteLine($"{num} is Odd");

        // Check range using switch with pattern matching
        switch (num)
        {
            case int n when (n >= 0 && n <= 10):
                Console.WriteLine("Range: 0–10");
                break;
            case int n when (n >= 11 && n <= 20):
                Console.WriteLine("Range: 11–20");
                break;
            default:
                Console.WriteLine("Out of range");
                break;
        }
    }
}



//      [Q11].
//    During a live coding session, you are asked to write a program that prints the 
//Fibonacci series using a for loop in C#. Provide a detailed explanation of your 
//approach, and explain how the loop is used to generate the series.  During a live coding session, you are asked to write a program that prints the 
//Fibonacci series using a for loop in C#. Provide a detailed explanation of your 
//approach, and explain how the loop is used to generate the series. 


//Solution

using System;
using System.Collections.Generic;

class FibonacciSeries
{
    static void Main()
    {
        Console.Write("Enter number of terms: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int first = 0, second = 1, next;

        Console.Write("Fibonacci Series: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(first + " ");
            next = first + second;
            first = second;
            second = next;
        }
    }
}

// Explanation:
//First two terms are 0 and 1.
//The for loop runs n times, each iteration calculating the next term as first + second.



//    [Q12].
//    You are leading a training session on loops in C#. Explain the key differences 
//between while and do-while loops, and provide examples of each where one 
//might be more appropriate than the other. You are leading a training session on loops in C#. Explain the key differences 
//between while and do-while loops, and provide examples of each where one 
//might be more appropriate than the other. 


//Solution

//|     Feature             |            `while` loop                        |       `do -while` loop         |
//| ----------------------- | ---------------------------------------------- | ------------------------------ |
//| Condition Checked | Before the loop                                      | After the loop                 |
//| Executes at least once? | ❌ Not guaranteed                              |  Always executes once          |
//| Use case                | When we don’t know if we need to run even once | When we must run at least once |

using System;

class WhileVsDoWhile
{
    static void Main()
    {
        int count = 5;

        Console.WriteLine("While loop:");
        while (count < 5)
        {
            Console.WriteLine(count);
            count++;
        }

        count = 5;
        Console.WriteLine("Do-While loop:");
        do
        {
            Console.WriteLine(count);
            count++;
        } while (count < 5);
    }
}




//    [Q13].
//    You are developing a pattern generation tool for a project. Write a program in C# 
//that uses nested loops to generate a pyramid pattern of stars (*). Explain how the 
//loops work together to produce the pattern.You are developing a pattern generation tool for a project. Write a program in C# 
//that uses nested loops to generate a pyramid pattern of stars (*). Explain how the 
//loops work together to produce the pattern


//Solution

using System;

class StarPattern
{
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= rows; i++)
        {
            // Print spaces
            for (int j = i; j < rows; j++)
                Console.Write(" ");

            // Print stars
            for (int k = 1; k <= (2 * i - 1); k++)
                Console.Write("*");

            Console.WriteLine();
        }
    }
}


//Explanation:

//Outer loop → controls number of rows.
//First inner loop → prints spaces before stars.
//Second inner loop → prints stars in pyramid shape.

//Example Output (rows = 5)
    *
   ***
  *****
 *******
*********



//   [Q14].
//     You are giving a presentation on object-oriented programming. Define 
//Encapsulation, Inheritance, Polymorphism, and Abstraction, and provide real
//world examples of each in the context of C# development.  You are giving a presentation on object-oriented programming. Define 
//Encapsulation, Inheritance, Polymorphism, and Abstraction, and provide real
//world examples of each in the context of C# development. 

//Solution



//Four Pillars of Object-Oriented Programming in C#

// 1. Encapsulation

//Encapsulation means hiding internal data and exposing only what’s necessary through public methods or properties.
// Real - world example: A BankAccount class hides the account balance and allows controlled access through Deposit() and Withdraw() methods.

class BankAccount
{
    private double balance;  // hidden data

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= balance)
            balance -= amount;
        else
            Console.WriteLine("Insufficient funds");
    }

    public double GetBalance()
    {
        return balance;
    }
}

// 2.Inheritance
//Inheritance allows a child class to acquire properties and methods of a parent class.
//🔹 Real - world example: A Car and Bike both inherit from a common Vehicle class.

class Vehicle
{
    public void Start() => Console.WriteLine("Vehicle started");
}

class Car : Vehicle
{
    public void Honk() => Console.WriteLine("Car honks!");
}

// 3.Polymorphism
//Polymorphism means one interface, many forms — the same method behaves differently depending on the object.
//🔹 Real-world example: A method Drive() behaves differently for Car and Bike.

class Vehicle
{
    public virtual void Drive() => Console.WriteLine("Driving a vehicle");
}

class Car : Vehicle
{
    public override void Drive() => Console.WriteLine("Driving a car");
}

class Bike : Vehicle
{
    public override void Drive() => Console.WriteLine("Riding a bike");
}

// 4.Abstraction
//Abstraction means showing only essential features while hiding the background details.
// Real-world example: A Payment abstract class defines ProcessPayment(), but specific payment types implement it differently.

abstract class Payment
{
    public abstract void ProcessPayment();
}

class CreditCardPayment : Payment
{
    public override void ProcessPayment() => Console.WriteLine("Processing Credit Card Payment");
}



//    [Q15].
//     In a team discussion, you are asked to demonstrate the use of constructors and 
//destructors in C#. Write a C# program that includes both, explaining the lifecycle 
//of an object from creation to destruction. In a team discussion, you are asked to demonstrate the use of constructors and 
//destructors in C#. Write a C# program that includes both, explaining the lifecycle 
//of an object from creation to destruction.

//Solution

using System;

class Demo
{
    public Demo()
    {
        Console.WriteLine("Constructor: Object is created.");
    }

    ~Demo()
    {
        Console.WriteLine("Destructor: Object is destroyed.");
    }

    static void Main()
    {
        Demo obj = new Demo();
        Console.WriteLine("Inside Main method.");
    }
}

//Explanation:
//Constructor is called when an object is created (used to initialize data).
//Destructor is called automatically by the garbage collector before object destruction.








//      [Q16].A team member is confused about access modifiers in C#. How would you 
//explain public, private, protected, and internal modifiers, and demonstrate their 
//use by writing a small C# class with methods using different access levels? . A team member is confused about access modifiers in C#. How would you 
//explain public, private, protected, and internal modifiers, and demonstrate their 
//use by writing a small C# class with methods using different access levels? 


//Solution


//| Modifier    |              Accessibility                       | Usage Example |
//| ----------- | ------------------------------------------------ | --------------------- |
//| `public`    | Accessible from anywhere                         | APIs, Utility Methods |
//| `private`   | Accessible only within same class                | Sensitive data fields |
//| `protected` | Accessible within same class and derived classes | Base class members    |
//| `internal`  | Accessible within the same assembly/project      | Shared library code   |


//using System;

class AccessExample
{
    public void PublicMethod() => Console.WriteLine("Public Method");
    private void PrivateMethod() => Console.WriteLine("Private Method");
    protected void ProtectedMethod() => Console.WriteLine("Protected Method");
    internal void InternalMethod() => Console.WriteLine("Internal Method");

    static void Main()
    {
        AccessExample obj = new AccessExample();
        obj.PublicMethod();
        obj.InternalMethod();
        // obj.PrivateMethod(); // ❌ Not accessible
        // obj.ProtectedMethod(); // ❌ Not accessible
    }
}







//[Q17].
// You are tasked with illustrating the concept of inheritance in C#. Write a program where a Vehicle class is inherited by
// a Car class and a Bike class, each with their own unique methods. Demonstrate how inheritance allows code reuse.
//You are tasked with illustrating the concept of inheritance in C#. Write a program where a Vehicle class is inherited by a Car class and a Bike class, 
// each with their own unique methods. Demonstrate how inheritance allows code reuse.

//Solution

using System;

class Vehicle
{
    public void Start() => Console.WriteLine("Vehicle starting...");
}

class Car : Vehicle
{
    public void Accelerate() => Console.WriteLine("Car accelerating...");
}

class Bike : Vehicle
{
    public void KickStart() => Console.WriteLine("Bike kick-started...");
}

class Program
{
    static void Main()
    {
        Car car = new Car();
        car.Start();       // Inherited method
        car.Accelerate();  // Unique method

        Bike bike = new Bike();
        bike.Start();      // Inherited method
        bike.KickStart();  // Unique method
    }
}

// Explanation:
//Car and Bike reuse Start() from Vehicle → demonstrates code reusability.




//      [Q18]
//In a bug-fixing scenario, your team needs to handle unexpected runtime errors. 
//Explain how the try-catch-finally blocks work in C# with an example of catching 
//and handling an arithmetic exception, and how finally is always executed. 


//Solution

using System;

class ExceptionDemo
{
    static void Main()
    {
        try
        {
            int a = 10, b = 0;
            int result = a / b; // ❌ Division by zero
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Finally block executed — resources cleaned up.");
        }
    }
}

// Explanation:
//try: Code that may cause an error.
//catch: Handles specific exception.
//finally: Runs always, even if an exception occurs.




//      [Q19]
//You are implementing a custom exception for a specific error scenario in your 
//application. Write a C# program that demonstrates exception handling by 
//throwing and catching a custom exception, explaining why custom exceptions are 
//beneficial


//Solution

using System;

class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message) { }
}

class CustomExceptionDemo
{
    static void CheckAge(int age)
    {
        if (age < 18)
            throw new InvalidAgeException("Age must be 18 or above to register.");
        else
            Console.WriteLine("Registration successful!");
    }

    static void Main()
    {
        try
        {
            CheckAge(15);
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine("Custom Exception: " + ex.Message);
        }
    }
}


//Explanation:
//Custom exceptions provide clear, domain-specific error messages.
//Improves debugging and error tracking in large applications.




//      [Q20]
//During a code quality meeting, you are asked to highlight the advantages of using
//exception handling in C#. Explain how proper exception handling improves 
//application’s robustness.



//Solution



//Advantages of Exception Handling in C#

Improves program reliability: Prevents crashes by handling unexpected errors gracefully.
Separates error logic: Keeps normal code clean and readable.
Maintains program flow: Allows recovery or fallback after an exception.
Supports debugging: Catching and logging exceptions helps identify problems early.
Resource management: finally ensures that files, connections, and memory are cleaned up properly.

//Example:

Without exception handling:

int a = 10, b = 0;
int c = a / b; // Program crashes


With exception handling:

try
{
    int a = 10, b = 0;
int c = a / b;
}
catch (DivideByZeroException)
{
    Console.WriteLine("Handled: Cannot divide by zero.");
}


______________________________________________________________END____________________________________________________