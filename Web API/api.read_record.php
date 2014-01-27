<?php
/*
?phone=
*/
    // include db handler
    require_once 'include/DB_update.php';
    
	if(empty($_POST["phone"]) )
		echo "Error: in input data\n";
	else{
		$db = new DB_update();
		$resultarray = $db->get_record($_POST["phone"]);
		$entry=1;
		echo "<table style=\"border:1px solid black;\">";
		//Display column names
		if (mysql_num_rows($resultarray) > 0) {
			$numfields = mysql_num_fields($resultarray);
			for ($i=0; $i < $numfields; $i++)
				echo '<th>'.mysql_field_name($resultarray, $i).'</th>'; 
		}
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
		echo "</table>";
	}
	?>