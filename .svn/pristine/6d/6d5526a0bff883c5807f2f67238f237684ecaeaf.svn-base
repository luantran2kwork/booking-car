import React, { useState } from "react";
import { NavigationContainer, CommonActions } from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";
import { createSwitchNavigator } from "@react-navigation/compat";
import { setTopLevelNavigator } from "./NavigationService";

import Default from "./RoleManagement/Default";
import AddNew from "./RoleManagement/AddNew";
import Display from "./RoleManagement/Display";
import Edit from "./RoleManagement/Edit";

// ? Default title style
const defaultTitleStyle = {
  headerStyle: {
    backgroundColor: "#2EA8EE",
  },
  headerTintColor: "#fff",
  headerTitleStyle: {
    fontWeight: "bold",
  },
  headerBackTitle: "",
};


const withNavStackAddNew = (Component) => (
  <Component
    {...this.props}
    name="AddNew"
    component={AddNew}
    options={({ navigation, route }) => ({
      ...defaultTitleStyle,
      headerShown: false,
    })}
  />
);

const withNavStackDisplay = (Component) => (
  <Component
    {...this.props}
    name="Display"
    component={Display}
    options={({ navigation, route }) => ({
      ...defaultTitleStyle,
      headerShown: false,
    })}
  />
);

const withNavStackEdit = (Component) => (
  <Component
    {...this.props}
    name="Edit"
    component={Edit}
    options={({ navigation, route }) => ({
      ...defaultTitleStyle,
      headerShown: false,
    })}
  />
);


const Stack = createStackNavigator();
function AppContainer() {
  return (
    <NavigationContainer
      ref={(navigationRef) => setTopLevelNavigator(navigationRef)}
    >
      <Stack.Navigator initialRouteName="Default">
        <Stack.Screen
          name="SwitchStack"
          component={SwitchStack}
          options={{ headerShown: false }}
        />
        {withNavStackAddNew(Stack.Screen)}
        {withNavStackDisplay(Stack.Screen)}
        {withNavStackEdit(Stack.Screen)}
      </Stack.Navigator>
    </NavigationContainer>
  );
}

const SwitchStack = createSwitchNavigator(
  {
    Default: Default,
  },
  {
    initialRouteName: "Default",
  }
);

export default AppContainer;
