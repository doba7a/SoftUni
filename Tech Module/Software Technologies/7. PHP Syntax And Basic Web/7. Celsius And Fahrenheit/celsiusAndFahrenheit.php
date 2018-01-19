<?php
$msgAfterCelsius = "";
$msgAfterFahrenheit = "";


if (isset($_GET["cel"])) {
    $celsius = htmlspecialchars($_GET["cel"]);
    $fahrenheitFromCelsius = floatval($celsius) * 1.8 + 32;
    $msgAfterCelsius = "$celsius &deg;C = $fahrenheitFromCelsius &deg;F";
}

if (isset($_GET["fah"])) {
    $fahrenheit = htmlspecialchars($_GET["fah"]);
    $celsiusFromFahrenheit = (floatval($fahrenheit) - 32) / 1.8;
    $msgAfterFahrenheit = "$fahrenheit &deg;F = $celsiusFromFahrenheit &deg;C";
}
?>

<form>
    Celsius: <input type="text" name="cel" />
    <input type="submit" value="Convert">
    <?= $msgAfterCelsius ?>
</form>
<form>
    Fahrenheit: <input type="text" name="fah" />
    <input type="submit" value="Convert">
    <?= $msgAfterFahrenheit ?>
</form>

