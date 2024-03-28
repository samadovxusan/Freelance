    using Delegate;
    
    
    
    // Func 
    Func<int , int ,double>  MyFunction = MetodDelegate.division;

    // lyambda expression with anonym metod
    Func<char , char , int> result =  (x, y) => x + y;
    
    //  delegate  with anonym metod
    Func<int> result2 = delegate()
    {
        int sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += i;
        }
        return sum;
    };
    
    // Action     not  return 
    Action<int> result3 = delegate(int x)
    {
        int sum = 0;
        for (int i = 0; i < x; i++)
        {
            sum += i;
        }
        Console.WriteLine(sum);
    };
    // result3.Invoke(10);
    // Action    with Method 
    Action<int, int> mymetod = MetodDelegate.Add;
    // mymetod.Invoke(10, 20);
    
    
    
    // Predicate
    Predicate<int> myPredicate = x => x > 10;
    // Console.WriteLine(myPredicate.Invoke(11));

    var myevent = new Myevent();   
    myevent.Letsgo();
    
