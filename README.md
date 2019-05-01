# Talks Organizer

version 0.7

The application receive a json of talks and define the best organization.

## Class Diagram
![Class Diagram](Talk/ClassDiagram.png)
## Entry

### talks.json
- duration in minutes
```json
[
  {
    "Title": "Writing Fast Tests Against Enterprise Rails 60min",
    "Duration": 60
  },
  {
    "Title": "Overdoing it in Python 45min",
    "Duration": 45
  }
  ...
]
```

### Available Days and hours

working!

## Output

print the best cenario
```txt
Total Left Minutes: 85

    Start 01/06/2019 09:00:00 ----Left: 0-

      Talks Accounting-Driven Development 45min 

      Talks Ruby on Rails Legacy App Maintenance 60min 

      Talks Woah 30min 

      Talks Clojure Ate Scala (on my project) 45min 

    Start 01/06/2019 14:00:00 ----Left: 40-

      Talks Rails for Python Developers lightning 

      Talks A World Without HackerNews 30min 

      Talks Ruby Errors from Mismatched Gem Versions 45min 

      Talks Overdoing it in Python 45min 

      Talks Common Ruby Errors 45min 

      Talks Programming in the Boondocks of Seattle 30min 

    Start 01/06/2019 09:00:00 ----Left: 0-

      Talks Communicating Over Distance 60min 

      Talks Ruby on Rails: Why We Should Move On 60min 

      Talks Sit Down and Write 30min 

      Talks Ruby vs. Clojure for Back-End Development 30min 

    Start 01/06/2019 14:00:00 ----Left: 45-

      Talks Rails Magic 60min 

      Talks Writing Fast Tests Against Enterprise Rails 60min 

      Talks Pair Programming vs Noise 45min 

      Talks Lua for the Masses 30min 
```
