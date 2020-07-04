import React, { useState } from "react";
import {
  Container,
  Jumbotron,
  Button,
  Form,
  FormGroup,
  Label,
  Row,
  Col,
} from "reactstrap";
import { useForm } from "react-hook-form";

const Odds = (props) => {
  //   const current = watch("odds_input");

  const { register, handleSubmit, errors } = useForm();
  const [result, setResult] = useState(null);
  const fetchData = async (inputs) => {
    const resp = await fetch("api/v1/odds", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(inputs),
    });
    const data = await resp.json();
    const res =
      data.status === "success"
        ? `${(data.data * 100).toFixed(2)}%`
        : "Invalid Input";
    setResult(res);
  };
  //   fetchData();
  const onSubmit = (data) => {
    console.log(data);
    fetchData(data);
  };

  return (
    <div>
      <Jumbotron fluid>
        <Container fluid>
          <header>
            <h1>Odds Calculator 5000!</h1>
          </header>
        </Container>
      </Jumbotron>
      <Container className="calc">
        <Row>
          <Col>
            <Form onSubmit={handleSubmit(onSubmit)}>
              <FormGroup>
                <Label for="odds_input">Enter American Odds</Label>
                <input
                  name="odds_input"
                  className="form-control"
                  ref={register({ required: true })}
                />
                {errors.odds_input && <span>This field is required</span>}
              </FormGroup>
              <Button>Submit</Button>
            </Form>
          </Col>
          <Col>
            <div className="result">{result && <div>{`${result}`}</div>}</div>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default Odds;
