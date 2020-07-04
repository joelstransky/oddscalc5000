import React from "react";
import { Route } from "react-router";
import Layout from "./components/Layout";
import Odds from "./components/Odds";

import "./custom.css";

const App = () => (
  <Layout>
    <Route exact path="/" component={Odds} />
  </Layout>
);
export default App;
