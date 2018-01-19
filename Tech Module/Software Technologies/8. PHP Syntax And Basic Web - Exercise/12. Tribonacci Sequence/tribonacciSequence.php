<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if(isset($_GET["num"])) {
    $num = intval($_GET["num"]);

    $fibonacciNums = [];
    $fibonacciNums[0] = 1;
    $fibonacciNums[1] = 1;
    $fibonacciNums[2] = 2;

    for ($i = 3; $i < $num; $i++){
        $fibonacciNums[$i] = $fibonacciNums[$i - 1] + $fibonacciNums[$i - 2] + $fibonacciNums[$i - 3];
    }

    $output = implode("\n", $fibonacciNums);

    echo $output;
}
?>
</body>
</html>