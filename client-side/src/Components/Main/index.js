import { Box, Stack, styled } from "@mui/material";
import React, { useState } from "react";
import MySearchTextField from "../Inputs/MySearchTextField";
import ButtonWithLoading from "../Buttons/ButtonWithLoading";

const StyledImg = styled("img")(({ theme }) => ({}));

const Main = () => {
  const [searchText, setSearchText] = useState("");
  const onSearchTextChange = (event) => {
    const value = event.target.value;
    setSearchText(value);
  };

  return (
    <Stack alignItems={"center"} spacing={3} paddingTop={10}>
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
