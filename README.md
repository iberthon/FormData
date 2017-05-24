This is a program developed for one of my customers.

They use an eCommerce system that sends emails from Newsletter Signups and Contact Us submissions in the following format:

Contact Form:

form_checked = Yes
thanks_url = /shop/shopping-help/contact-us.html?success=1
data_name = contact-form.xlsx
customer_name = A Customer
customer_age = over 18
customer_email = an@email.address.com
customer_number = 012324 567890
customer_message = Message Body line 1
line 2
line 3
.
.
.
line n
submit = Submit
IP: xx.xx.xx.xx/xx.xx.xx.xx

Newsletter Signup:

data_name = newsletter-signup.xls
thanks_url = /shop/shopping-help/newsletter.html
first_name = FirstName
last_name = LastName
email = an@email.address.com
submit =
IP: xx.xx.xx.xx/xx.xx.xx.xx

This program uses the MailKit (https://github.com/jstedfast/MailKit) to retrieve the messages using IMAP and present them to the customer in a format the can 

a) read
b) use with MailChimp to send out Newsletters and promotional material

At the moment it is very basic as I'm not a C# expert and this is the first time I've used MailKit.

Over time I plan to add features to enable emails to be deleted and (maybe) forwarded to another address and I'm sure the code will get refactored a few times as my C# skills improve.