# TheatreAPI

### List of endpoints

1) GET api/Theatre
    - Description
         - Gets all the theatres in the database.
    - Request Body 
        - None
    - Response Body
         ```    
          {
            "statusCodes": 200,
            "statusDescription": "Successfully retrieve everything!!! :)",
            "movies": [],
            "theatres": [
                {
            "theatreId": 1,
            "name": "REGAL E-WALK 4DX & RPX",
            "address": "247 W. 42nd St., New York, NY 10036",
            "phone_no": "(844)462-7342",
            "movies": []
                }
            ]
                }
        ```
            
2) POST api/Theatre
    - Description
         - Insert the new theatre in the database.
    - Request Body 
        ```
        {
        "theatreId": 11,
        "name": "AMC LOEWS FRESH MEADOWS 7",
        "address": "190-02 Horace Harding Blvd., Fresh Meadows, NY 11365",
        "phone_no": "(718) 454-6767",
        "movies": [
        ]
            }
        ```
    - Response Body
        ```    
          {
            "statusCodes": 200,
            "statusDescription": "Added successfully :)",
            "movies": [],
            "theatres": []
            }
        ```
3) DELETE api/Theatre/{id}
     - Description
         - Delete the theatre with matching ID in the database.
    - Request Body 
        - None
    - Response Body
        ```    
          {
            "statusCodes": 404,
            "statusDescription": "Deleted Successfully",
            "movies": [],
            "theatres": []
            }
        ```
        
4) GET api/Theatre/{id}
    - Description
        - Get the theatre with matching ID in the database.
    - Request Body 
        - None
    - Response Body
        ```    
          {
            "statusCodes": 200,
            "statusDescription": "Successfully retrieve everything!!! :)",
            "movies": [],
            "theatres": [
                {
                    "theatreId": 9,
                    "name": "REGAL UA MIDWAY",
                    "address": "108-22 Queens Blvd., Forest Hills, NY 11375",
                    "phone_no": "(844) 462-7342",
                    "movies": [
                        {
                            "movieId": 2,
                            "name": "Father Stu",
                            "genre": "Drama",
                            "director": "Rosalind Ross",
                            "theatreId": 9
                        }
                    ]
                }
                ]
         }
     ```
5) GET api/Movie
    - Description
         - Gets all the movie in the database.
    - Request Body 
        - None
    - Response Body
         ```    
          {
            "statusCodes": 200,
            "statusDescription": "Successfully retrieve everything!!! :)",
            "movies": [
                {
                    "movieId": 1,
                    "name": "The NorthMan",
                    "genre": "Action/Adventure",
                    "director": "Robert Eggers",
                    "theatreId": 8
                },
                {
                    "movieId": 2,
                    "name": "Father Stu",
                    "genre": "Drama",
                    "director": "Rosalind Ross",
                    "theatreId": 9
                },
                {
                    "movieId": 3,
                    "name": "The Batman",
                    "genre": "Action/Adventure",
                    "director": "Matt Reeves",
                    "theatreId": 8
                }
            ],
            "theatres": []
        }
       ```
            
6) POST api/Movie
    - Description
         - Insert the new movie in the database.
    - Request Body 
        ```
        {
            "movieId": 5,
            "name": "The Equalizer",
            "genre": "Action/Thriler",
            "director": "Antoine Fuqua",
            "theatreId": 6
        }
        ```
    - Response Body
        ```    
          {
            "statusCodes": 200,
            "statusDescription": "Added successfully :)",
            "movies": [],
            "theatres": []
          }
        ```
7) DELETE api/Movie/{id}
     - Description
         - Delete the movie with matching ID in the database.
    - Request Body 
        - None
    - Response Body
        ```    
          {
            "statusCodes": 404,
            "statusDescription": "Deleted Successfully. :)",
            "movies": [],
            "theatres": []
            }
        ```
        
8) GET api/Movie/{id}
    - Description
        - Get the movie with matching ID in the database.
    - Request Body 
        - None
    - Response Body
        ```    
        {
            "statusCodes": 200,
            "statusDescription": "Successfully retrieve everything!!! :)",
            "movies": [
                {
                    "movieId": 1,
                    "name": "The NorthMan",
                    "genre": "Action/Adventure",
                    "director": "Robert Eggers",
                    "theatreId": 8
                }
            ],
            "theatres": []
        }
    ```
