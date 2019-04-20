# BirthdayReminder

This console app sends a birthday reminder email daily.

## Getting started

### Email setup

1. Open App.config file
2. Set a valid email from address
3. Set the email from address password
4. Enter a comma separated destination addresses

### Birthday list setup

1. Open Birthdays.txt file
2. Enter a json list containing persons' name, birthday, first work day and specify if send the email like the example:
```
[
   { "Birthday" : "1984-04-20", "FirstWorkDay" : "2016-05-02", "Name" : "James Smith", "SendEmail" : "true" },
   { "Birthday" : "1990-03-02", "FirstWorkDay" : "2013-12-22", "Name" : "Anthony Brown", "SendEmail" : "true" },
   { "Birthday" : "1957-06-12", "FirstWorkDay" : "2017-12-03", "Name" : "Anne Yoret", "SendEmail" : "false" }
]
```

### Templates setup

1. Place your templates in the Templates folder 
2. Make sure your html file contains a variable named {name}

## Built With

* [.NET Core 2.1](https://docs.microsoft.com/en-us/aspnet/) - The framework used

## Authors

* **Rodrigo López** - *Initial work* - [rolo1091](https://github.com/rolo1091)

## License

This project is licensed under the MIT License
