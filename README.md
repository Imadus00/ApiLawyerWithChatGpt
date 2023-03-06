# Contract Question API

The Contract Question API is a C# program that uses the OpenAI API to answer questions related to a contract. The program allows users to upload a contract in PDF format and ask questions about its clauses. The program then extracts the text from the contract using the `ExtractTextFromPdf` method and sends the question and contract text to the OpenAI API using the `SendChatGPTRequest3` method. The API generates a response as if it were a legal expert, indicating whether certain clauses of the contract are legal or not. The response is then returned to the user as a string.

## Getting Started

To use this program, you will need an OpenAI API key, which can be obtained from the OpenAI website. Once you have obtained an API key, follow these steps:

1. Install .NET Core 3.1 or later on your computer.
2. Clone or download this repository to your local machine.
3. Replace the "Your KEY" string in the program with your OpenAI API key.
4. Navigate to the directory where the program is saved using the terminal or command prompt.
5. Run the program by entering the following command:

6. Use a tool such as Postman or cURL to make a POST request to the endpoint `http://localhost:5000/contract` with a `form-data` body containing a PDF file and a string parameter `question`.

## How It Works

The program uses the `ExtractTextFromPdf` method to extract the text from the PDF file of the contract. It then uses the `SendChatGPTRequest3` method to send the question and contract text to the OpenAI API using the `OpenAIAPI` library. The API generates a response, which is returned as a string to the client. The program is built as a RESTful API using ASP.NET Core and can be hosted on a server to provide a public endpoint for generating contract-related questions.

In addition to the `ExtractTextFromPdf` and `SendChatGPTRequest3` methods, the program also includes an `ILogger` instance to log errors and a `Post` method that handles incoming HTTP POST requests. The `Post` method receives a PDF file and a string parameter `question` in the `form-data` body of the request. It then calls the `ExtractTextFromPdf` method to extract the text from the PDF file and the `SendChatGPTRequest3` method to generate a response to the question using the OpenAI API. Finally, the response is returned as an HTTP OK (200) status code to the client. If an error occurs during the processing of the request, an HTTP Internal Server Error (500) status code is returned instead.

## Libraries Used

The program uses the following libraries:

- `Microsoft.AspNetCore.Mvc`: For building RESTful APIs.
- `Microsoft.Extensions.Logging`: For logging errors.
- `OpenAI_API.Completions` and `OpenAI_API`: For interacting with the OpenAI API.
- `iTextSharp.text.pdf` and `iTextSharp.text.pdf.parser`: For extracting text from the PDF file.
- `Microsoft.AspNetCore.Cors`: For enabling CORS (Cross-Origin Resource Sharing).
- `System.Text.Json.Serialization`: For JSON serialization.

## Demostration

![image](https://user-images.githubusercontent.com/122009354/223137331-bc65cf54-09cd-4bed-99df-2414e164b77d.png)


## Conclusion

The Contract Question API provides a convenient and efficient way for users to quickly and easily ask questions about the clauses of a contract and receive legal feedback. It is a Proof of Concept (PoC) that demonstrates the capabilities of the OpenAI API for generating responses to legal questions related to contracts. The program can be used as a starting point for building more advanced applications that incorporate the OpenAI API and other tools for legal analysis and compliance.


