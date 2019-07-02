<?php
session_start();


 
	if(!empty($_POST['fullname']) && !empty($_POST['email']) && !empty($_POST['password']) && !empty($_POST['confirmpassword'])){
 
		// VARIABLE
 
		$fullname     = $_POST['fullname'];
		$email        = $_POST['email'];
		$password     = $_POST['password'];
		$confpassword = $_POST['confirmpassword'];
 
		// TEST SI PASSWORD = PASSWORD CONFIRM
 
		if($password != $confirmpassword){
				header('Location: index.php?error=1&pass=1');
					exit();
 
		}
 
		// TEST SI EMAIL UTILISE
		$req = $db->prepare("SELECT count(*) as numberEmail FROM users WHERE email = ?");
		$req->execute(array($email));
 
		while($email_verification = $req->fetch()){
			if($email_verification['numberEmail'] != 0) {
				header('location: index.php?error=1&email=1');
				exit();
 			}
		}
 
		// HASH
 		$secret = sha1($email).time();
		$secret = sha1($secret).time().time();
 
		// CRYPTAGE DU PASSWORD
 		$password = "aq1".sha1($password."1254")."25";
 
		// ENVOI DE LA REQUETE
 		$req = $db->prepare("INSERT INTO users(fullname, email, password, secret) VALUES(?,?,?,?)");
		$value = $req->execute(array($fullname, $email, $password, $secret));
			
		header('location: index.php?success=1');
		exit();
 
 	}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Sign In - Suggest</title>
	<link rel="stylesheet" href="log.css">
	<link rel="icon" type="image/png" href="favicon.ico" />
</head>
<body>

<?php
		if(!isset($_SESSION['connect'])){ ?>



<div class="container" id="container">
	<div class="form-container sign-up-container">
		<form method="post" action="index.php">
			<h1>Create Account</h1>
			<div class="social-container">
				<a href="#" class="social"><img src="images/facebook.svg" height="20"></a>
				<a href="#" class="social"><img src="images/google.svg" height="20"></a>
			</div>
			<span class="or-email">or use your email for registration</span>
			<input type="text" name="fullname"  placeholder="Fullname" required/>
			<input type="email" name="email" placeholder="Email" required/>
			<input type="password" name="password" placeholder="Password" required/>
			<input type="password" name="confirmpassword" placeholder="Confirm Password" required/>
			<button type='submit' class="signin-second">Sign Up</button>
		</form>
		<?php
		 
		 if(isset($_GET['error'])){
	  
			 if(isset($_GET['password'])){
				 echo '<p id="error">Les mots de passe ne correspondent pas.</p>';
			 }
			 else if(isset($_GET['email'])){
				 echo '<p id="error">Cette adresse email est déjà utilisée.</p>';
			 }
		 }
		 else if(isset($_GET['success'])){
			 echo '<p id="success">Inscription prise correctement en compte.</p>';
		 }
	  
	 ?>
	</div>
	<div class="form-container sign-in-container">

	</div>
	<div class="overlay-container">
		<div class="overlay">
			<div class="overlay-panel overlay-left">
				<img src="images/movie2.png" class="movie">
				<p>Sign up to discover the SUGGEST universe</p><br>
				<button class="ghost" id="signIn">Home</button>
			</div>
			<div class="overlay-panel overlay-right">
				<img src="images/movie2.png" class="movie">
				<h1 class="title-welcome">Welcome !</h1><br><br>
				<button class="ghost" id="signUp">Sign Up</button>
			</div>
		</div>
	</div>
</div>

		


			
<script>
	const signUpButton = document.getElementById('signUp');
	const signInButton = document.getElementById('signIn');
	const container = document.getElementById('container');

	signUpButton.addEventListener('click', () => {
		container.classList.add("right-panel-active");
		});

	signInButton.addEventListener('click', () => {
		container.classList.remove("right-panel-active");
		});
</script>
<?php } else { ?>
<?php } ?>
</body>
</html>