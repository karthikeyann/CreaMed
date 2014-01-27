<form action="<?php echo $_SERVER['PHP_SELF'] ?>" method="post">
<p>
Patient Phone number <input type="tel" size="10" name="phone" maxlength="10" value=""/>  <br>
Name <input type="text"size="50" name="name" value=""/>  <br>
Age <input type="number" size="3" name="age" value=""/>  <br>
DOB <input type="date" size="10" name="DOB" value="YYYY-MM-DD"/>  <br>
Sex <input type="text" size="1" name="sex" value="M"/>  <br>
</p><p>
<input type="submit" name="run" value="Save Patient data"/>
</p><p>

<?php
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
