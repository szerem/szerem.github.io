import React from "react";
import { Container, Button, Form } from "react-bootstrap";

const Search = ({ word, setWord, handleSubmit }) => {
  return (
    <Container className="justify-content-md-center">
      <Form onSubmit={handleSubmit}>
        <Form.Group>
          <Form.Control
            type="text"
            value={word}
            onChange={(e) => setWord(e.target.value)}
            placeholder="Search for new image..."
          />
          <Button variant="primary" type="submit">
            Search
          </Button>
        </Form.Group>
      </Form>
    </Container>
  );
};

export default Search;
