import React from 'react';
//import { Admin, Resource } from 'react-admin';
import jsonServerProvider from 'ra-data-json-server';
import { Admin, Resource } from 'react-admin';
import { ProductList ,ProductEdit,ProductCreate } from './products';
import { UsersList, UserEdit, UserCreate } from './users';

const dataProvider = jsonServerProvider('http://localhost:56885/api/');
const App = () => (
  <Admin dataProvider={dataProvider}>
      <Resource name="product" list={ProductList} edit={ProductEdit} create ={ProductCreate}  /> 
      <Resource name="users" list={UsersList}  edit={UserEdit} create={UserCreate} />      
  </Admin>
);

export default App;
