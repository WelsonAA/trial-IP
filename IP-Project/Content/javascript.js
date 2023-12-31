
    // Set up click event handlers after the entire page has loaded, including styles and images

    var scriptElement = document.createElement('script');
scriptElement.src = 'https://kit.fontawesome.com/2e3b9c6e89.js';
scriptElement.crossOrigin = 'anonymous';

// Append the script element to the document head
document.head.appendChild(scriptElement);


 function createaccount() {
        window.location.href = "Signup.html";
        
    };
 function Applycoupon()
 {
    var amount_total=document.getElementById("totalamount");
    amount_total.innerHTML="20% Coupon applied price now 2400 LE Only"
 }   
        function login() {
        window.location.href = "index.html";
    };
    function shopnow() {
        window.location.href = "Shopnow.html";
    };

function women_Section()
{
    window.location.href="Womeh_Hoodies.html";
}

function men_Section()
{
    window.location.href="Men_Hoodies.html";
}

function Shirtsoffer()
{
    window.location.href="Shirts.html";
}
function sunglasses()
{
    window.location.href="sunglasses.html";
}

/* This code is related to pay now button in cart page */

document.addEventListener('DOMContentLoaded', function() {
    var payNowBtn = document.getElementById('paynowbtn');
  var totalamout=document.getElementById('totalamount');
  var seeStoreBtn = document.getElementById('seestorebtn');
  var storeVideo = document.getElementById('storeVideo');
  var aftertransaction=document.getElementById('aftertransaction');
  var shoppingcartlink=document.getElementById('shoppingcartlink');
  var shoppingcartsymbol=document.getElementById('shoppingcartsymbol');
  
      // Add a click event listener to the button
  
      if (payNowBtn) {
        payNowBtn.addEventListener('click', function() {
            alert("Congratulations🎉 on Your Purchase Your transaction was done successfully")
            // Change the HTML content of the button
            totalamout.innerHTML = '! Order will arrive By Thursday 7/12/2023 ! ';
            aftertransaction.innerHTML='Thank You For using Tobgy Store ♥ ';
            
        });
      }
  /* This function was made as in about-us page button named see store opening video to show and hide video with pause ans start effect */
      if (seeStoreBtn) {
        seeStoreBtn.addEventListener('click', function() {
            // Toggle the visibility of the video element
            if (storeVideo.style.display === 'none') {
                storeVideo.style.display = 'block';  // changing attribute value 
                seestorebtn.innerHTML="Click Here to Hide video";
                storeVideo.play();
                
            } else {
                storeVideo.style.display = 'none';
                seestorebtn.innerHTML="See Store Opening Video";
                storeVideo.pause()
            }
            /*This part is to take screen to video directly by scrolling down a bit when button is clicked*/
            storeVideo.scrollIntoView({
                behavior: 'smooth', 
                block: 'center' 
            });
        });
      }

      if (shoppingcartlink) {
        shoppingcartlink.addEventListener('click', function() {
            alert("Item Added to Chart");
            shoppingcartsymbol.style.backgroundColor = 'red';
            
        });
      }
   
 

      
  });

  

/*Navigate to other page*/
/*change inner html */
/*Show video by pressing btn and play it when it is shown automatically using js*/
/*hide video using js by pressiong btn*/
/*to make alert */
/* to scroll down to video when button is pressed*/
 /*Change style */




 


// Create a script element for Font Awesome
