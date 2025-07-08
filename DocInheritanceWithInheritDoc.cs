public class AddManager{
    /// <summary>
    /// Adds two integers<br/>
    /// Hi from AddManager.Add doc
    /// </summary>
    /// <param name="a">First integer, hi from AddManager.Add doc</param>
    /// <param name="b">Second integer, hi from AddManager.Add doc</param>
    /// <returns>Sum of two integers, hi from AddManager.Add doc</returns>
    public int Add(int a, int b){
        return a + b;
    }

    /// <summary>
    /// Subtracts two integers<br/>
    /// Hi from AddManager.Add2 doc
    /// </summary>
    /// <param name="a">First integer, hi from AddManager.Add2 doc</param>
    /// <param name="b">Second integer, hi from AddManager.Add2 doc</param>
    /// <returns>Sum of two integers, hi from AddManager.Add2 doc</returns>
    public int Add2(int a, int b){
        return a + b;
    }

    /// <inheritdoc cref="Add"/>
    public int Add3(int a, int b){
        return a + b;
    }

    /// <inheritdoc cref="Add2"/>
    public int Add4(int a, int b){
        return a + b;
    }
}

public class AddManager2{
    /// <inheritdoc cref="AddManager.Add"/>
    public int Add(int a, int b){ // a normal inherit doc
        return a + b;
    }

    /// <inheritdoc cref="AddManager.Add2"/>
    public int Add2(int a, int b){ // a normal inherit doc
        return a + b;
    }

    /// <summary>
    /// Adds three integers<br/>
    /// Hi from AddManager2.AddAdvanced doc
    /// </summary>
    /// <inheritdoc cref="AddManager.Add3"/>
    /// <param name="c">Third integer, hi from AddManager2.AddAdvanced doc</param>
    public int AddAdvanced(int a, int b, int c){ // partial inherit doc, this is rarely used, but works in Rider
        return a + b + c;
    }
}

public class TestDocInheritanceByInheritDoc{
    public void Test(){
        // call every method from the two class here
        AddManager addManager = new AddManager();
        addManager.Add(1, 2); // mouse hover should show all docs from AddManager.Add doc
        addManager.Add2(1, 2); // mouse hover should show all docs from AddManager.Add2 doc
        addManager.Add3(1, 2); // mouse hover should show all docs from AddManager.Add doc
        addManager.Add4(1, 2); // mouse hover should show all docs from AddManager.Add2 doc

        AddManager2 addManager2 = new AddManager2();
        addManager2.Add(1, 2); // mouse hover should show all docs from AddManager.Add doc
        addManager2.Add2(1, 2); // mouse hover should show all docs from AddManager.Add2 doc
        addManager2.AddAdvanced(1, 2, 3); // (advanced, this is rarely used) mouse hover should show some docs from AddManager.Add, with summary and param c from AddManager2.AddAdvanced doc
        
        // rider behave as expected in all cases here
    }
}
