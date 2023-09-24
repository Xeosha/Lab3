

using System.Transactions;

double borderA = 0.1;   // дано по заданию
double borderB = 1;     // дано по заданию
int k = 10;             // дано по заданию
int n = 10;             // кол-во итераций 2 формулы (SN)
double e = 0.0001;      // эпсилон точности (SE)


for (var x = borderA; x <= borderB; x += (borderB - borderA) / k)
{
    Console.WriteLine($"X = {x,20:F20} " +
        $"SN = {FormulaSN(n, x),20:F20} " +
        $"SE = {FormulaSE(n, x, e),20:F20} " +
        $"Y = {Formula(x),20:F20}");
}





double FormulaRecurent(int n, double x)
{

    return (-1) * (x * x) / (2*n*(2*n-1));
}

double FormulaSN(int n, double x)
{
    double result =  1;
    double recurentResult = result;

    for (int i = 1; i < n; i++)
    {
        recurentResult = recurentResult * FormulaRecurent(i, x);
        result += recurentResult;
    }

    return result;
}

double FormulaSE(int n, double x, double epsilon)
{
    double result = 1;
    double recurentResult = result;
    double previousResult;

    int i = 1;
    do
    {
        previousResult = result;
        recurentResult = recurentResult * FormulaRecurent(i, x);
        result += recurentResult;
        i++;
    } while (Math.Abs(result - previousResult) > epsilon) ;

    return result;
}

double Formula(double x)
{
    return Math.Cos(x);
}


