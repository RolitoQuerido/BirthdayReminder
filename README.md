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
2. Enter a json list containing persons' name and birthday like the example:
```
[
   { "Birthday" : "1984-10-14", "Name" : "James Smith" },
   { "Birthday" : "1990-03-19", "Name" : "Anthony Brown" }
]
```

## Built With

* [.NET Core 2.1](https://docs.microsoft.com/en-us/aspnet/) - The framework used

## Authors

* **Rodrigo López** - *Initial work* - [rolo1091](https://github.com/rolo1091)

## License

This project is licensed under the MIT License
