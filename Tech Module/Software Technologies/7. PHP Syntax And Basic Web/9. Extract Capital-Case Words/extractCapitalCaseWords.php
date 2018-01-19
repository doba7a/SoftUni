<?php
$capitalCaseWords = "";

if (isset($_GET["text"])){
    $text = $_GET["text"];
    preg_match_all('/\w+/', $text, $words);
    $words = $words[0];

    $capitalCaseWords = array_filter($words, function($word){
        return strtoupper($word) == $word;
    });

    $capitalCaseWords = implode(', ', $capitalCaseWords);
}
?>

<form>
    <textarea rows="10" name="text"><?= $capitalCaseWords
        ?></textarea> <br>
    <input type="submit" value="Extract">
</form>


