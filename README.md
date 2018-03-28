# API Enhnacements

When we ended Lab 6, you were asked to do some API testing to see what you found.

## Books API

1. GET /api/books
    * Response is *200 OK* with an empty array: `[]`
    * We don't have books in our database yet, we need to POST them.
1. GET /api/books/1
    * Response is *404 Not Found*
    * We don't have books in our database yet, we need to POST them.
1. POST /api/books
    * Request with an empty payload => Response is *201 Created* with null values:
    ```JSON
        {
            "id": 1,
            "title": null,
            "author": null,
            "isbn": null,
            "publishDate": "0001-01-01T00:00:00",
            "publisher": null
        }
    ```
    * We can essentially submit a null Book based on the way the API generates types. We have to do some extra things to handle this scenario
    * Request with a Book payload => Response is *201 Created* with bad array in the body:

        _Request_
        ```JSON
            {
                "title": "Accelerate",
                "author": {
                    "name": "Nicole Forsgren",
                    "bio": "ssss"
                    },
                "isbn": "978-1942788331",
                "publishDate": "2018-03-17T00:00:00",
                "publisher": "IT Revolution Press"
            }
        ```
        * Notice the way Author is defined. Author is a complex C# object, and we have to submit a JSON object in the same way. This may have caused some issues for you.
        _Response_

        **Bad Array** - this is due to the way the API tries to serialize Book and it's child class Author. We will fix this as part of the bonus lab.

    * The response header means the record saved, and you will notice that the record is still created in the database.
1. DELETE /api/books/1
    * This should work as originally designed
1. PUT /api/books/1

## Authors API

1. The Authors behave almost identically to Books.

## TODO

[ ] Do not allow null submissions.
[ ] Fix JSON serializer.
[ ] Don't change Author in the Books API