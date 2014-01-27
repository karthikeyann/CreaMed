<head>
<title> Doctor Diagnosis
</title>
</head>
<body bgcolor="53436A" >
<font color="White"> <center>
<h2>Hi, Doctor. Enter Patient Diagnosis details</h2>
<table style="border:1px solid White;color:White">
<form action="<?php echo $_SERVER['PHP_SELF'] ?>" method="post">
<tr>
<td>Doctor name </td><td><input type="text" size="20" name="doctor" maxlength="50" value=""/></td>   
</tr><tr>
<td>
Patient Id number </td><td><input type="tel" size="20" name="phone" maxlength="10" value=""/> </td> 
</tr><tr>
<td>
Problem/Symptoms</td><td> <input type="text" size="50" name="problem" value=""/> </td> 
</tr><tr>
<td>
Diagnosis </td><td><input type="text" size="50" name="diagnosis" value=""/> </td> 
</tr><tr>
<td>
Medication:	Drug name   </td><td>  Time &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; No.of.Days </td>
</tr><tr>
<td>
<input type="text" size="100" name="drug1" value=""/> </td><td><input type="time" size="5" name="time1" value="08:00"/>   <input type="number" size="2" name="days1" value=""/>  </td>
</tr><tr>
<td>
<input type="text" size="100" name="drug2" value=""/> </td><td> <input type="time" size="5" name="time2" value="11:00"/> <input type="number" size="2" name="days2" value=""/></td> 
</tr><tr>
<td>
<input type="text" size="100" name="drug3" value=""/> </td><td> <input type="time" size="5" name="time3" value="14:00"/>  <input type="number" size="2" name="days3" value=""/> </td>
</tr><tr>
<td>
<input type="text" size="100" name="drug4" value=""/> </td><td> <input type="time" size="5" name="time4" value="21:00"/>  <input type="number" size="2" name="days4" value=""/></td> 
</tr><tr>
<td>
Reports </td>
</tr><tr><td>
<textarea name="reports" rows="4" cols="50">
 X-ray
 </textarea> </td> 
 </tr><tr>
<td>
 Next appointment <input type="text" size="10" name="nextappointment" maxlength="10" value="2014-12-31 23:30"/>  
</p>
</td>
</tr><tr>
<p><td><center>
<input  class="classname" type="submit" name="run" value="Save Patient data"/></center>
<p>
</td></tr>
</table>
<style type="text/css">
.classname {
	background-color:#53436A;
	-webkit-border-top-left-radius:0px;
	-moz-border-radius-topleft:0px;
	border-top-left-radius:0px;
	-webkit-border-top-right-radius:0px;
	-moz-border-radius-topright:0px;
	border-top-right-radius:0px;
	-webkit-border-bottom-right-radius:0px;
	-moz-border-radius-bottomright:0px;
	border-bottom-right-radius:0px;
	-webkit-border-bottom-left-radius:0px;
	-moz-border-radius-bottomleft:0px;
	border-bottom-left-radius:0px;
	text-indent:0;
	border:1px solid #dcdcdc;
	display:inline-block;
	color:White;
	font-family:arial;
	font-size:15px;
	font-weight:bold;
	font-style:normal;
	height:50px;
	line-height:50px;
	width:150x;
	text-decoration:none;
	text-align:center;
}.classname:hover {
	background-color:#53537A;
}.classname:active {
	position:relative;
	top:1px;
}</style>
<?php
    // include db handler
    require_once 'include/DB_update.php';
	if(empty($_POST["phone"]) or empty($_POST["problem"]) )
		echo "\n"; //Error: in input data
	else{
		$db = new DB_update();
		$med1=""; $med2=""; $med3=""; $med4="";
		if(!empty($_POST["drug1"]))
			$med1= $_POST["drug1"]."#".$_POST["time1"]."#".$_POST["days1"];
		if(!empty($_POST["drug2"]))
			$med2= $_POST["drug2"]."#".$_POST["time2"]."#".$_POST["days2"];
		if(!empty($_POST["drug3"]))
			$med3= $_POST["drug3"]."#".$_POST["time3"]."#".$_POST["days3"];
		if(!empty($_POST["drug4"]))
			$med4= $_POST["drug4"]."#".$_POST["time4"]."#".$_POST["days4"];
		$result = $db->store_record($_POST["phone"],$_POST["problem"],$_POST["diagnosis"],$_POST["doctor"],$_POST["reports"],$_POST["nextappointment"],$med1,$med2,$med3,$med4);
		if($result==false)
			echo "Error in saving the user details";
		else
			echo $result;
		}
		// UPDATE `medpil`.`patient_info` SET `phone` = '9489244684' WHERE `patient_info`.`phone` =2147483647;
	?>
</font>
<center>
</body>