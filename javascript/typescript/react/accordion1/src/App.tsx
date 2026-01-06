import React, { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";

import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger,
} from "./accordion/accordion";

type AccordionProps = {
  id: string;
  title: string;
  description: string;
};

const list: AccordionProps[] = [
  {
    id: "1",
    title: "Title 1",
    description: "Description 1",
  },
  {
    id: "2",
    title: "Title 2",
    description: "Description 2",
  },
  {
    id: "3",
    title: "Title 3",
    description: "Descirption 3",
  },
];

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <div>
        <a href="https://vite.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
      <Accordion>
        {list.map((item) => (
          <AccordionItem id={item.id}>
            <AccordionTrigger> {item.title}</AccordionTrigger>
            <AccordionContent>{item.description}</AccordionContent>
          </AccordionItem>
        ))}
      </Accordion>
    </>
  );
}

export default App;
