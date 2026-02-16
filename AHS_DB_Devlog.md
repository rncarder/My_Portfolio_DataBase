AHSDB Devlog:
1/31/26 -
I have an idea to create a database for American Horror story. the database is going to be made using sql database services and Microsoft entity frameworks. I started by planning out the tables first table is going to be for the seasons which will use the id propery as season number and a Name(string) property. The second table will be for episodes which will use the id property for the episode number a Name(string) property and a SeasonId(int) property for the season it is in. the third table will be for the Cast which will have an Id property and a Name(string) property for the name of the cast member. the Fourth table will be for the Characters which will include an Id property, a Name(string) property a CastId(int) property to assign the cast member who played that character and a SeasonId(int) property to assign the season in which that character was in. The one problem I am seeing with this database is that some characters in American horror story was used in more than one season and sql services does not allow collections so I will not be able to make a list of seasons the character played in.

2/1/26 - 
i Have created schema for the American horror story database and migrated it to my local server. and verified on ssms that it the migration was successful.

2/2/26 - 
I started creating to separate apps in windows forms. One to enter new data into data base I named AHSDataEntry. and another called AHSQuery too query exisisting data in the database.

-- AHSDataEntry -- 
this has four buttons on the first form named Form1. These four buttons are labeled add season, add episode, add cast, add character. Each one of these buttons open a different form each form is named after the table they are effecting. The season form has a label labeled name, a TextBox where user inputs the name of the season, and a button to run the method that puts that data into the database. similarly all forms will have these three controls and possibly more to complete the table. as the episode needs to information for which season it is in i added a comboBox(dropdown) consisting of the seasons that are found in the database. I stopped there to work on the AHSQuery app to make sure the data is being put in correctly by the AHSDataEntry app.

--AHSQuery--
this one only has one form which consists  of a label labeled search a Textbox so the user can enter the name, a comboBox that consists of the four tables, a datagridview to display the data, and a button to  the app to search for the name entered in the textbox in the table selected from the dropdown. If a season is searched then it displays the seasons(Id) the season name and the episodes that have a seasonId that matches the season id. if an episode is searched then it will show the episode number(id) and the season name that has an Id that matches the episodes seasonId. If a cast member is searched it shows simply the cast members name and id thus far. if a character is searched it will show the characters id, the characters name, the cast Members name whose id matches the characters CastId and the seasons name  whose id matches the characters SeasonId.

2/3/26 --
I added a feature to the AHSQuery app where when the user selects a table from the dropdown it will display  all data in that table. I Also figured out a way to settle the problem where when a character is in more than one season. By my reciliation i cant think of a character that has played in more than two seasons so a made a nullable Season2Id(int) property and changed the property seasonId property to Season1Id. I then migrated the changes and checked ssms to verify the changes were made correctly. Then i added the controls to each app the functionality and appearance are exactly as season1 controls are that is the labels now are labeled Season1 and Season2 and the dropdowns consist of all the seasons names in the database. I started adding more features to the AHSDataEntry app which gives the user the ability to update or remove rows in each table in case of mistakes or new columns are added. I started with characters and sense there is a lot of properties in the characters dataset I made a new form named CharacterUpdateForm this form has a dropdown for characters names the user has to choose from that dropdown in order to choose which character row they are updating and a textbox to correct the name if needed comboboxes to change the cast, season1, season2 if needed can be left blank if no changes are needed in that "cell". also in that form i added a remove section that has a dropdown with all characters and a button the user selects which character from the dropdown they want to delete and press the button. all the others i just made a section on the corresponding form instead of creating a new form for each of the other tables each form has a dropdown consisting of its name. the user chooses a name from the dropdown a textbox a user can fix the name with and a button to commit changes or another button to delete that row from its table. epsiodes also has another dropdown for the seasons if they need to change the season the episode was in.....EVERYONE MAKES MISTAKES nice to have software that allows 
you to fix those mistakes.

2/4/26--
I had realized it  would be nice to have a property in characters that describes the number of episodes they were in so i updated the Model in the schema to add another two properties named season1NumOfEpsiodes and season2NumOfepisodes which simply holds the number of episodes the character appeared in that season. i migrated the schema verified through ssms that the changes have been made correctly and I updated the AHSDataEntry app to include a textbox for the two properties in the add and update forms for the characters. I did not need to make changes to the AHSQuery app as it just pulls the columns and rows from the database.

2/5/26 and 2/6/26 --
took a short break to recharge.

2/7/26 --
--created a security system for the database--
I setup in ssms a login and password for editor of database and a guest. the editor has read/write privileges. the guest only has read privileges. the AHSDataEntry app needs a login for the controls to be accessible. Now when the AHSDataEnty app is opened the only button on the first form is the login button. when that button is clicked it will open a new form where the user can put in there username and password and if the username and password are correct then all the buttons on the first form will appear and be accessible. and the login form will close automatically. and the login/logout button text will say logout and when that button is clicked while user is logged in it will logout and the buttons will disappear. as of for now if the client wants to add another user they will need to get ahold of the administrator to do so through ssms. In the AHSQuery app the user will automatically be logged in as guest when opened as i dont see any reason to restrict the viewing of this the data in this particular database as its not sensitive data.

2/8/26
"Hit a wall with Identity gaps (1, 2, 5...) and realized SQL IDs aren't always sequential. After research, the logic of why they persist made sense, so I 'nuked' the DB and used RESEED to start fresh.
I refactored the parameters to stop relying on SelectedIndex and moved to SelectedValue linked to the DataTable ID. This ensures the correct record is targeted regardless of gaps. I also added a SeasonNumber property to the Seasons table for better chronological tracking.
Created a Helper class with List<string> for table columns to eliminate redundant string typing. I used Lambda expressions to filter the lists (like removing 'Id' for Inserts) to prevent crashes. Security is handled via SQL Login at the start, so the connection string stays clean."

2/9/26
I created a dll named AHS.Core in it i put a class called AHSProvider. it has all the tablenames in  a string data type, each tables name in separate lists and methodds to call when accessing the database. However i used a global tool search tool to search through my project and rename certain calls from sharedfields to AHSProvider in doing so the search tool was a Little aggressive and renamed a line in the .cproj xml i file I had a hard time locating the problem and spent most of the day trying to find that. I spent a little more time refactoring my code in AHSDataEntry. also set any SQLupdate or SqlRemove controls in the app visibility to false as they were going to be to costly on time for the V1.0 minimum viable Product. I will refactor The query app tomorrow.

2/10/26
I refactored the Query app removed alot of unneeded  ui controls within this app as they are not needed to push an minimum viable product. i added the dll i created yesterday AHS.Core to the dependencies and changed those pesty stings to call on that dll.

2/11/26
In the AHSDataEntry app i added a method in the UIHelper class to make sure there is no duplicated data baing added to the database I a also changed the UIHelper.TextParsing method to UItextboxchecker and made it a little bit more recyclable in that it doesn't only check the textboxes that needs ints and now it checks the textboxes that needs strings. i added an method to make sure the comboboxes are not empty some are nullable so i use conditional statements to make sure it is not nullable.. product will be ready  for git push tomorrow.. 

2/12/26
made into github repository..took screenshots of app funcionting as i ecpected it to.

12/13/26
worked on version 2.0 . implementing unit of work to reduce latency and improve ux. Found enviromental conflicts during the update and fixed the conflicts. Am going to stick with the standard ADO.net (rawsql) to ensure connection stability.

2/14/26
took time away to unplug from technology and reduce burnout.

2/15/26
implented the unit of work logic to all scripts. refactored my duplication checks. took a whole 10 line method out added a new method that checks the buffer and adds the new row to the buffer if the the row doesnt exsist. rebuilt the architecture to make the models accesible to all files to ensure making it easier to fetch and set rows

2/16/26
Enchanced the UX by adding a panel in the characters form to add cast and seasons if needed by the user. This will reduce the need to click out of forms to make the ux to make the process of adding a new character row to the database easierand more seemless. Please excuse the queryApp as it has been getting ignored quiet a bit lately. Plan on adding a search field to the queryApp and the cells clickable to display all information needed more accessible. 
