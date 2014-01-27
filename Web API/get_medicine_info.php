<form action="<?php echo $_SERVER['PHP_SELF'] ?>" method="post">
<p>
Patient Phone number <input type="tel" name="phone" maxlength="10" value=""/>  
</p><p>
<input type="submit" name="run" value="Get Patient data"/>
</p><p>
<?php
    // include db handler
    require_once 'include/DB_update.php';
    
	if(empty($_POST["phone"]) )
		echo "Error: in input data\n";
	else{
		$db = new DB_update();
		$resultarray = $db->get_record($_POST["phone"]);
		$entry=1;
		//Display Entries
		while ($row = mysql_fetch_array($resultarray))
		{
			echo "<tr>";
			for($i=0; $i<$numfields; $i++)         
			{    
			//foreach($row as $key => $value){ 
					echo '<td>'.$row[$i].'</td>'; 
			} 
			echo "</tr>";
			$entry++;
		}
	}
	?>
