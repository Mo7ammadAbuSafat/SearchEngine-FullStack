# Custom Search Engine

![image](https://github.com/Mo7ammadAbuSafat/SearchEngine-FullStack/assets/103439731/003b7955-a98d-468b-9631-5f89eda14979)

## Table of Contents

- [Description](#description)
- [Technologies Used](#technologies-used)
- [Features](#features)
- [Building the Inverted Index](#building-the-inverted-index)
- [Searching Algorithm](#searching-algorithm)
- [Installation](#installation)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Description

The Custom Search Engine is a powerful tool that allows users to perform efficient and accurate text searches within a dataset. The project is built using .NET Core for the backend API and ReactJS for the frontend.


## Technologies Used

### Backend

- C#
- ASP.NET Core API
- Tokenization
- Stop Words Handling
- Stemming
- Inverted Indexing

### Frontend (ReactJS)

- JavaScript
- ReactJS
- MUI

## Features

1. **Dataset Upload**: Users can upload a dataset of strings in CSV format to be used for indexing and searching.

2. **Indexing Options**:
   - Tokenization: Users can choose the tokenization method e.g.:
   a- Stop Words: Option to include or exclude common stop words in the indexing process.
   b- Allow Frequent Terms: Users can decide whether to include frequent terms in each document or not.
   - Stemming: Option to apply stemming to index the root form of words.

3. **Inverted Index Building**: The system builds the inverted index based on the selected options to facilitate efficient searching.

![image](https://github.com/Mo7ammadAbuSafat/SearchEngine-FullStack/assets/103439731/9dd219cf-ffc1-4e3b-a8f8-dbe91ee0dad9)


4. **Search Text**: Users can enter search queries, and the system will tokenize and apply stemming using the same indexing options to deliver relevant results.

5. **Scoring and Ranking**: The search results are scored based on the number of matched terms, and the documents are displayed in descending order by rank.

![image](https://github.com/Mo7ammadAbuSafat/SearchEngine-FullStack/assets/103439731/4d04db39-a3b9-4c82-8b6d-d89f6eacdf92)


## Building the Inverted Index

The inverted index is a crucial data structure used to speed up the process of searching for terms within a dataset. The system allows users to customize the index construction. The process involves the following steps:

1. **Tokenization**: The dataset is broken down into individual tokens based on the selected tokenization way.

2. **Stop Words**: If the option to exclude stop words is chosen, common words like "the," "and," "is," etc., will be removed from the tokens.

3. **Allow Frequent Terms**: Users can decide whether to include frequently occurring terms in each document or not.

4. **Stemming**: If selected, the system applies stemming to the tokens to reduce words to their root form (e.g., "running" becomes "run").

5. **Inverted Index Creation**: The system constructs the inverted index, mapping each term to the list of documents containing that term.

## Searching Algorithm

The searching algorithm involves tokenizing and applying stemming to the user's search query, using the same options chosen during the index construction. The algorithm then scores the results based on the number of matched terms and presents the documents in descending order by rank.

## Installation

To run this project locally, follow these steps:

1. Clone the repository.
2. Navigate to the project directory for both the backend and frontend.
3. Install backend dependencies: `dotnet restore`
4. Start the backend server: `dotnet run`
5. Install frontend dependencies: `npm install`
6. Start the frontend development server: `npm start`
7. Open your browser and go to `http://localhost:3000` to access the website.

## Contributing

Contributions to this project are welcome! If you find any bugs or have suggestions for improvement, please feel free to open an issue or submit a pull request.

1. Fork the project.
2. Create your feature branch: `git checkout -b feature/my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin feature/my-new-feature`
5. Submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).


## Contact

If you have any questions or feedback regarding this project, you can reach me at:
- Email: mo7ammad.abusafat@gmail.com
- LinkedIn: https://www.linkedin.com/in/mohammad-abusafat/
