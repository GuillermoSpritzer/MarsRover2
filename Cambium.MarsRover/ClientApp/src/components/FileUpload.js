import React, { useState } from "react";
import axios from "axios";
import { render } from "react-dom";

export const FileUpload = () => {
  const [file, setFile] = useState();
  const [fileName, setFileName] = useState();
  const [output, setOutput] = useState();
  const [instructions, setInstruction] = useState();
  const [PlateauHeight, setPlateauHeight] = useState();
  const [PlateauWidth, setPlateauWidth] = useState();



  const PostMarsRoverInstructions = async (e) => {
    try{
    const Instructions = JSON.stringify({ PlateauWidth: Number(PlateauWidth ?? 5),PlateauHeight:Number(PlateauHeight ?? 5), Instructions: instructions});
    const response = await axios.post("Navigation",Instructions ,     { headers: { 'Content-Type': 'application/json' },});
    setOutput((output + "\n" + response.data).replace("undefined",""));
  } catch (ex) {
    console.log(ex);
    setOutput(ex.response.data);
    }
  };  

  const handleChange = (e) => {
    console.log(e.target.value);
    setInstruction(e.target.value);
  };

  const saveFile = (e) => {
    console.log(e.target.files[0]);
    setFile(e.target.files[0]);
    setFileName(e.target.files[0].name);
  };

  const uploadFile = async (e) => {
    console.log(file);
    const formData = new FormData();
    formData.append("formFile", file);
    formData.append("fileName", fileName);
    formData.append("PlateauHeight", Number(PlateauHeight ?? 5));
    formData.append("PlateauWidth", Number(PlateauWidth ?? 5));
    try {
      const res = await axios.post("file", formData);
      setOutput((output + "\n" + res.data).replace("undefined",""));
    } catch (ex) {
      console.log(ex);
      setOutput(ex.response.data);
    }
  };

  const handleChangeIntHeight = (e) => {
    const name= e.target.name;
    setPlateauHeight(e.target.value);
  };

  
  const handleChangeIntWidth= (e) => {
    const name= e.target.name;
    setPlateauWidth(e.target.value);
  };



  return (
    <div>
      <div class="card" >
        <div class="input-group mb-3">
          <div class="card-body">

          <div >
        Enter plateu Dimensions   
        Width  <input type="number" id="width" name="PlateauWidth" min="1" max="100" class = "foo"
         value= {PlateauWidth} 
         onChange= {handleChangeIntWidth}/>
        Height  <input type="number" id="width" name="PlateauHeight" min="1" max="100" class = "foo" 
        value= {PlateauHeight} 
        onChange= {handleChangeIntHeight} />
        </div>
        <br/>
      <input type="file" onChange={saveFile} />
      <br/>
      <br/>
      <input type="button" value="Deploy File rovers" onClick={uploadFile} />
      <br/>
      <br/>
      <div>
        Enter instructions for new mars Rover <input type="text" value={instructions} onChange= {handleChange} />
        <br/>
        <input type="button" value="Deploy Rover" onClick= {PostMarsRoverInstructions} />
        <br/>
      </div>
     
      </div>
                </div>
            </div>
            <div class="alert alert-success" role="alert">
                <div class="textwrapper">
                <textarea name="body" rows="10"  value= {output}/>
                </div>
            </div>
       </div>

  );

};