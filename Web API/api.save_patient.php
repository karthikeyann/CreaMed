<?php
/*
?phone=
&name=
&age=
&DOB=YYYY-MM-DD
&sex=M
*/
    // include db handler
    require_once 'include/DB_update.php';
    
	if(empty($_POST["phone"]) or empty($_POST["name"]) )
		echo "Error: in input data\n";
	else{
		$db = new DB_update();
		$result = $db->put_patient_details($_POST["phone"], $_POST["name"], $_POST["age"], $_POST["DOB"], $_POST["sex"]);
		if($result==false)
			echo "Error in saving the user details";
		else
			echo $result;
		}
		// UPDATE `medpil`.`patient_info` SET `phone` = '9489244684' WHERE `patient_info`.`phone` =2147483647;
	?>
