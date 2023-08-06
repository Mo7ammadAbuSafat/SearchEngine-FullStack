import { Button, Stack } from "@mui/material";
import React, { useState } from "react";
import MySearchTextField from "../Inputs/MySearchTextField";
import ButtonWithLoading from "../Buttons/ButtonWithLoading";
import FormToBuildNewInvertedIndex from "../Forms/FormToBuildNewInvertedIndex";
import PopupModal from "../PopupModal";

const Main = () => {
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
        <ButtonWithLoading label={"Search"} />
      </Stack>
    </Stack>
  );
};

export default Main;
