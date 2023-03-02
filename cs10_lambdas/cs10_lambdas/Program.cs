
using System.Runtime.CompilerServices;

int Filter1(int v)
{
    if(v<0) v = 0; return v;
}

int Operation(int a, int b, Func<int, int> f, [CallerArgumentExpression("f")]string? paramName = null)
{ 
    a=f(a);
    b=f(b);
    Console.WriteLine("Fonction de filtrage : " + paramName);
    return a + b; 
}

var filter2 = (int v) => v >10 ? 10 : v;

Console.WriteLine(Operation(-5,150, filter2));