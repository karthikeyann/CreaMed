<?php
/*?doctor=
&phone=
&problem=
&diagnosis=
&drug1=&time1=&days1=
&drug2=&time2=&days2=
&drug3=&time3=&days3=
&drug4=&time4=&days4=
&reports=*/

/*
<form action="<?php echo $_SERVER['PHP_SELF'] ?>" method="post">
<p>
Doctor name (hidden if log in created)<input type="text" size="10" name="doctor" maxlength="50" value=""/>  <br> 
Patient Id number <input type="tel" size="10" name="phone" maxlength="10" value=""/>  <br>
Problem/Symptoms <input type="text" size="100" name="problem" value=""/>  <br>
Diagnosis <input type="text" size="100" name="diagnosis" value=""/>  <br>
Medication:	Drug name   ---  Time --- No of Days <br>
<input type="text" size="100" name="drug1" value=""/>  <input type="time" size="5" name="time1" value="08:00"/>  <input type="number" size="2" name="days1" value=""/> <br>
<input type="text" size="100" name="drug2" value=""/>  <input type="time" size="5" name="time2" value="11:00"/>  <input type="number" size="2" name="days2" value=""/> <br>
<input type="text" size="100" name="drug3" value=""/>  <input type="time" size="5" name="time3" value="14:00"/>  <input type="number" size="2" name="days3" value=""/> <br>
<input type="text" size="100" name="drug4" value=""/>  <input type="time" size="5" name="time4" value="21:00"/>  <input type="number" size="2" name="days4" value=""/> <br>
Reports <br>
<textarea name="reports" rows="4" cols="50">
 X-ray
 </textarea>  <br>
 Next appointment <input type="text" size="10" name="nextappointment" maxlength="10" value="2014-12-31 23:30"/>  <br>
</p><p>
<input type="submit" name="run" value="Save Patient data"/>
</p><p>
*/
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