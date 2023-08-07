import { Button, Card, Pagination, Stack, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import MySearchTextField from "../Inputs/MySearchTextField";
import ButtonWithLoading from "../Buttons/ButtonWithLoading";
import FormToBuildNewInvertedIndex from "../Forms/FormToBuildNewInvertedIndex";
import PopupModal from "../PopupModal";
import axios from "axios";

const Main = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [searchText, setSearchText] = useState("");
  const onSearchTextChange = (event) => {
    const value = event.target.value;
    setSearchText(value);
  };
  const [openSettingsPopup, setOpenSettingsPopup] = useState(false);
  const handleSettingsClick = () => {
    setOpenSettingsPopup(true);
  };
  const handleClosSettingsPopup = () => {
    setOpenSettingsPopup(false);
  };

  const [NumOfRelevantDocuments, setNumOfRelevantDocuments] = useState(null);
  const [data, setData] = useState(null);
  const [pageNumber, setPageNumber] = useState(1);
  const handlePageChange = (event, value) => {
    setPageNumber(value);
    onSubmit();
  };
  const [numOfPages, setNumOfPages] = useState(1);

  useEffect(() => {
    onSubmit();
  }, [pageNumber]);

  const onSubmit = async (e) => {
    if (searchText !== "") {
      setIsLoading(true);
      await axios
        .get(`https://localhost:7235/api/documents`, {
          params: {
            searchText: searchText,
            pageSize: 10,
            pageNumber: pageNumber,
          },
          headers: {
            Accept: "application/json",
            "Content-Type": "multipart/form-data",
          },
        })
        .then((response) => {
          setData(response.data.documents);
          setNumOfPages(response.data.numOfPages);
          setNumOfRelevantDocuments(response.data.relevantDocumentsCount);
        })
        .catch((error) => {
          console.log(error);
          if (error.response) {
            var errorMessage = error.response.data.error;
            alert("Error: ", errorMessage);
          } else {
            alert("Error: ", error.message);
          }
        });
    }
    setIsLoading(false);
  };

  return (
    <Stack alignItems={"center"} spacing={3} paddingTop={10}>
      <Button
        sx={{
          position: "absolute",
          top: "15px",
          right: "15px",
          border: "1px solid",
        }}
        onClick={handleSettingsClick}
      >
        Add Dataset
      </Button>
      <PopupModal
        name={"Build new inverted index"}
        open={openSettingsPopup}
        fullWidth={true}
        handleClose={handleClosSettingsPopup}
      >
        <FormToBuildNewInvertedIndex />
      </PopupModal>
      <Stack maxWidth={"40%"}>
        <img alt="" src="/Assets/My Search-1.png" />
      </Stack>
      <MySearchTextField
        value={searchText}
        onChange={onSearchTextChange}
        placeholder={"type a search query"}
      />
      <Stack>
        <ButtonWithLoading
          label={"Search"}
          isLoading={isLoading}
          onClick={onSubmit}
        />
      </Stack>
      {data && (
        <Typography>
          Number of relevant Documents: {NumOfRelevantDocuments}
        </Typography>
      )}
      {data && (
        <Pagination
          count={numOfPages}
          page={pageNumber}
          onChange={handlePageChange}
          color="primary"
        />
      )}
      {data && (
        <Stack width={"60%"} spacing={3}>
          {data.map((item) => (
            <Card
              sx={{
                padding: 3,
                boxShadow: "1px 3px 34px 0px rgba(0,0,0,0.3)",
                borderRadius: "20px",
              }}
            >
              <Stack spacing={2}>
                <Typography sx={{ backgroundColor: "silver", padding: 1 }}>
                  Score: {item.score}
                </Typography>
                <Typography>{item.text}</Typography>
              </Stack>
            </Card>
          ))}
        </Stack>
      )}
    </Stack>
  );
};

export default Main;
