<?php
$servername = "localhost";
$username = "root";
$password = "ascent";
$dbname = "atlantis";
$name = $_REQUEST["name"];
$score = $_REQUEST["score"];

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error)
{
die("connection failed" . $conn->connect_error);
}
echo"connected successfully";

$stmt = $conn->prepare("INSERT INTO highscore(Name,Score)VALUES(?,?)");
$stmt->bind_param("ss",$name,$score);
$stmt->execute();

$stmt->close();
$conn->close();
?>