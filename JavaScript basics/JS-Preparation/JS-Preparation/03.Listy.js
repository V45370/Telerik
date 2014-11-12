function solve(args) {
    function parseOperation(operationStart) {
        var indexOfWhiteSpace = poperationStart.trim().indexOf(' ') !== -1,
            name,
            func;

        if (indexOfWhiteSpace ===-1) {
            name = operationStart;
            func = '';
        }
        else {
            
            name = operationStart.substring(0, indexOfWhiteSpace).trim();
            func = operationStart.substring(indexOfWhiteSpace).trim();
        }
        return {
            name: name,
            func: func
        };
    }
    function parseOperation(lines) {
        var operations = [];
        for (var i = 0; i < lines.length; i++) {
            var line = lines[i];
            //parts[0] -> variable + function
            //parts[1] -> values
            var parts = line.split('[');
            var operationName = parseOperation(parts[0]);
            console.dir(operation);
        }

        //return [
        //    {
        //        operation: 'sum',
        //        value: '[1,2,3]',
        //        name: 'func2'
        //    }]
        
    }
    var lines = args.map(function (item) {
        item = item.trim();
        if (item.indexOf('def ') !== 0) {
            return item;
        }
        item = item.substr('def '.length).trim();
        return item;
    });
    
    var opetarions = parseOperation(lines);
    console.log(lines);
}
var test1 = [
    'def func   sum[5, 3,     7,   2  , 6  , 3]',
    'def func2 [5,    3, 7,    2, 6, 3]',
    'def func3 min[func2]',
    'def     func4    max[5,   3   , 7,   2, 6, 3]',
    'def    func5    avg[    5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4',
    'sum[func6, func4]'
];
solve(test1);