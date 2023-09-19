if (args.Length != 0)
{
    var brackets = args[0];

    var result = IsCorrect(brackets);

    Console.WriteLine(result);
}
else
{
    Console.WriteLine("Первый параметр должен содержать последовательность скобок");
}

static bool IsCorrect(string? brackets)
{
    var result = false;
    if (brackets == null) return false;

    const string validCharacters = "()[]{}";
    //Проверка на отсутствие символов кроме скобок
    foreach (var bracket in brackets)
    {
        if (!validCharacters.Contains(bracket))
            return result;
    }

    //Проверка на четность количества элементов для предположения наличия пар
    var length = brackets.Length;
    if (length % 2 != 0) return result;

    result = IsCorrectPairs(brackets);

    return result;
}

static bool IsCorrectPairs(string brackets)
{
    var openClosePair = new Dictionary<char, char>
    {
        { '(', ')'},
        { '[', ']'},
        { '{', '}'}
    };
    var openBracketStack = new Stack<char>();

    foreach (var bracket in brackets)
    {
        //Открывающая скобка кладется в стек
        if (openClosePair.ContainsKey(bracket))
        {
            openBracketStack.Push(bracket);
            continue;
        }

        //Проверяется наличие открывающей скобки для закрывающей
        if (!openBracketStack.Any()) return false;
        var element = openBracketStack.Pop();
        if (openClosePair[element] != bracket)
            return false;
    }

    if (openBracketStack.Count != 0) return false;

    return true;
}