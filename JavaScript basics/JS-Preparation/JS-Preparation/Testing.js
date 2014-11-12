function solve(args) {
    var lines = args;
    
    var functionNames = {};
    for (i in lines)
    {
        var line = lines[i];
        //REMOVE WHITESPACE
        var lineNoSpace = line.split(' ');
        //REMOVE EMPTY STRINGS
        lines[i] = lineNoSpace.filter(function (value) {
            if (value==='') {
                return false;
            }
            else {
                return true;
            }
        });
        
        for(j in lines[i])
        {
            var operationNumbers = [];
            
            var line2 = lines[i][j];
            var afterBracketVar = 0;
            var functionsName = 0;
            var calculate = false;
            //CHECK IF OPEN BRACKET
            if (line2.indexOf('[') >= 0) {
                //TAKE OPERATION NAME BEFORE BRACKET
                var indexOfBracket = line2.indexOf('[');
                var operationName = line2.substr(0, indexOfBracket);

                //TAKE VALUE OR FUNCTION AFTER BRACKET
                if (indexOfBracket + 1 < line2.length) {
                    
                    afterBracketVar = line2.substr(indexOfBracket+1, line2.length);
                    if (isFinite(parseInt(afterBracketVar))) {
                        operationNumbers.push(parseInt(afterBracketVar));
                    }
                    else {
                        //TRIM ',' and ']'
                        afterBracketVar = afterBracketVar.replace(',', '');
                        afterBracketVar = afterBracketVar.replace(']', '');
                        operationNumbers.push(parseInt(functionNames[afterBracketVar]));
                        
                        
                    }
                }
                
            }

            //CHECK IF NUMBER
            else if (isFinite(parseInt(line2))) {
                               
                operationNumbers.push(parseInt(line2));
            }

            //IGNORE  ,
            else if (line2 === ',') {
                
            }
            //IGNORE  def
            else if (line2 === 'def') {

            }
            //CHECK IF NAME OF FUCTION
            else {

                functionsName = line2.replace(',', '');
                functionsName = functionsName.replace(']', '');
                //Calculate for this functionName
                if (!functionNames[functionsName]) {
                    calculate = true;
                }
                    //Add value of functionName to opeartionNumbers
                else {
                    operationNumbers.push(functionNames[functionName]);
                }
                console.log(functionsName);
                
                
            }
            if (calculate) {
                var operationValue = 0;
                if (operationName ==='sum') {
                    for(var k = 0 ; k < operationNumbers.length ; k++)
                    {
                        operationValue += operationNumbers[k];
                    }
                }
                if (operationName === 'avg') {
                    for (var k = 0 ; k < operationNumbers.length ; k++) {
                        operationValue += operationNumbers[k];
                    }
                    operationValue /= operationNumbers.length;
                }
                if (operationName === 'max') {
                    var max = operationNumbers[0];
                    for (var k = 0 ; k < operationNumbers.length ; k++) {
                        
                        if (operationNumbers[i]>max) {
                            max = operationNumbers[i];
                        }
                        
                    }
                    operationValue = max;
                }
                if (operationName === 'min') {
                    var min = operationNumbers[0];
                    for (var k = 0 ; k < operationNumbers.length ; k++) {

                        if (operationNumbers[i] < min) {
                            min = operationNumbers[i];
                        }

                    }
                    operationValue = min;
                }

            }      

        }
        
        
    }
    
    console.log(operationValue);
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