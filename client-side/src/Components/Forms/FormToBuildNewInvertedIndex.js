import {
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
  Stack,
  Typography,
} from "@mui/material";
import React, { useState } from "react";
import MyInputFile from "../Inputs/MyInputFile";
import axios from "axios";
import ButtonWithLoading from "../Buttons/ButtonWithLoading";

const FormToBuildNewInvertedIndex = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [tokenizeType, setTokenizeType] = useState("with-stop-words");
  const handleTokenizeTypeChange = (event) => {
    setTokenizeType(event.target.value);
  };
  const [isAllowedFrequency, setIsAllowedFrequency] = useState(true);
  const handleIsAllowedFrequencyChange = (event) => {
    setIsAllowedFrequency(event.target.value);
  };
  const [isWithStemming, setIsWithStemming] = useState(false);
  const handleIsWithStemmingChange = (event) => {
    setIsWithStemming(event.target.value);
  };
  const [file, setFile] = useState(null);
  const handleFileChange = (event) => {
    setFile(event.target.files[0]);
  };
  const onSubmit = async (e) => {
    if (file !== null) {
      setIsLoading(true);
      const formData = new FormData();
      formData.append("file", file);
      await axios
        .post(`https://localhost:7235/api/documents`, formData, {
          params: {
            tokenizeType: tokenizeType,
            isAllowedFrequency: isAllowedFrequency,
            isWithStemming: isWithStemming,
          },
          headers: {
            Accept: "application/json",
            "Content-Type": "multipart/form-data",
          },
        })
        .then((response) => {
          alert("successful build");
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
    <Stack spacing={4} paddingTop={2}>
      <Stack direction={"row"} alignItems={"center"} spacing={2}>
        <MyInputFile handleFileChange={handleFileChange} />
        {file && <Typography>{file.name}</Typography>}
      </Stack>

      <Stack spacing={2}>
        <FormControl>
          <FormLabel id="demo-controlled-radio-buttons-group">
            Tokenize Type
          </FormLabel>
          <RadioGroup
            aria-labelledby="demo-controlled-radio-buttons-group"
            name="controlled-radio-buttons-group"
            onChange={handleTokenizeTypeChange}
          >
            <FormControlLabel
              value="with-stop-words"
              control={<Radio />}
              label="with stop words"
            />
            <FormControlLabel
              value="without-stop-words"
              control={<Radio />}
              label="without stop words"
            />
          </RadioGroup>
        </FormControl>
        <FormControl>
          <FormLabel id="demo-controlled-radio-buttons-group">
            Frequency Option
          </FormLabel>
          <RadioGroup
            aria-labelledby="demo-controlled-radio-buttons-group"
            name="controlled-radio-buttons-group"
            onChange={handleIsAllowedFrequencyChange}
          >
            <FormControlLabel
              value={true}
              control={<Radio />}
              label="allow frequent terms"
            />
            <FormControlLabel
              value={false}
              control={<Radio />}
              label="don't allow frequent terms"
            />
          </RadioGroup>
        </FormControl>
        <FormControl>
          <FormLabel id="demo-controlled-radio-buttons-group">
            Is With Stemming
          </FormLabel>
          <RadioGroup
            aria-labelledby="demo-controlled-radio-buttons-group"
            name="controlled-radio-buttons-group"
            onChange={handleIsWithStemmingChange}
          >
            <FormControlLabel
              value={true}
              control={<Radio />}
              label="with stemming"
            />
            <FormControlLabel
              value={false}
              control={<Radio />}
              label="without stemming"
            />
          </RadioGroup>
        </FormControl>
      </Stack>
      <ButtonWithLoading
        label={"submit"}
        onClick={onSubmit}
        isLoading={isLoading}
      />
    </Stack>
  );
};

export default FormToBuildNewInvertedIndex;
