
public interface ISomeInterface{

    /// <summary>
    /// Sums two integers<br/>
    /// Hi from interface doc
    /// </summary>
    /// <param name="a">First integer</param>
    /// <param name="b">Second integer</param>
    /// <returns>Sum of two integers</returns>
    public int Add(int a, int b);

    /// <summary>
    /// Subtracts two integers<br/>
    /// Hi from interface doc
    /// </summary>
    /// <param name="a">First integer</param>
    public int Subtract(int a, int b);

    /// <summary>
    /// Multiplies two integers<br/>
    /// Hi from interface doc
    /// </summary>
    /// <param name="a">First integer</param>
    /// <param name="b">Second integer</param>
    /// <returns>Product of two integers</returns>
    public int Multiply(int a, int b);

    /// <summary>
    /// Divides two integers<br/>
    /// Hi from interface doc
    /// </summary>
    /// <param name="a">First integer</param>
    /// <param name="b">Second integer</param>
    /// <returns>Quotient of two integers</returns>
    public int Divide(int a, int b);
}


public class SomeBaseClass : ISomeInterface{
    /// <summary>
    /// Adds two integers<br/>
    /// Hi from base class doc
    /// </summary>
    /// <param name="a">First integer</param>
    /// <param name="b">Second integer</param>
    /// <returns>Sum of two integers</returns>
    public virtual int Add(int a, int b){ // override interface doc here in base class
        return a + b;
    }

    /// <summary>
    /// Subtracts two integers<br/>
    /// Hi from base class doc
    /// </summary>
    public virtual int Subtract(int a, int b) // override doc here in base class
    {
        return a - b;
    }

    public virtual int Divide(int a, int b)
    {
        return a / b;
    }

    public virtual int Multiply(int a, int b)
    {
        return a * b;
    }
}

public class SomeClass : SomeBaseClass{
    public override int Add(int a, int b){ // should show docs from base class
        return a - b;
    }

    /// <summary>
    /// Subtracts two integers<br/>
    /// Hi from derived class doc
    /// </summary>
    /// <param name="a">First integer</param>
    /// <param name="b">Second integer</param>
    /// <returns>Difference of two integers</returns>
    public override int Subtract(int a, int b){ // override interface doc from base class here in derived class
        return a - b;
    }

    /// <summary>
    /// Multiplies two integers<br/>
    /// Hi from derived class doc
    /// </summary>
    /// <param name="a">First integer</param>
    /// <param name="b">Second integer</param>
    /// <returns>Product of two integers</returns>
    public int Multiply(int a, int b){ // override interface doc from interface here in derived class
        return a / b;
    }


    public int Divide(int a, int b){ // should inherit interface doc from interface
        return a / b;
    }
}

public static class TestDocInheritanceByHierarchy{
    public static void Test(){
        SomeBaseClass someBaseClass = new();
        someBaseClass.Add(1, 2); // mouse hover should show docs from base class
        someBaseClass.Subtract(1, 2); // mouse hover should show docs from base class
        someBaseClass.Multiply(1, 2);// mouse hover should show docs from interface
        someBaseClass.Divide(1, 2); // mouse hover should show docs from interface
        
        SomeClass someClass = new();
        someClass.Add(1, 2); // mouse hover should show docs from base class
        someClass.Subtract(1, 2); // mouse hover should show docs from derived class
        someClass.Multiply(1, 2);// mouse hover should show docs from derived class
        someClass.Divide(1, 2); // mouse hover should show docs from interface(which is logical, but Rider doesn't do it, I don't know why)
        
       // Rider behaves as expected in all cases except for the last case, which Rider doesn't show any xml docs 
    }
}
